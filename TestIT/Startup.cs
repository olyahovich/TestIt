using AspNet.Security.OpenIdConnect.Primitives;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using NJsonSchema;
using NSwag;
using NSwag.AspNetCore;
using NSwag.SwaggerGeneration.WebApi.Processors.Security;
using RabbitMQ.Client;
using RawRabbit;
using RawRabbit.Configuration;
using RawRabbit.Enrichers.GlobalExecutionId;
using RawRabbit.vNext;
using RawRabbit.vNext.Logging;
using RawRabbit.vNext.Pipe;
using Serilog;
using Serilog.Events;
using StaticDotNet.EntityFrameworkCore.ModelConfiguration;
using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using AspNet.Security.OAuth.Validation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using TestIT.Data;
using TestIT.Entities;
using ExchangeType = RawRabbit.Configuration.Exchange.ExchangeType;
using ILogger = Serilog.ILogger;


namespace TestIT.Web
{
    public class Startup
    {
        private IHostingEnvironment CurrentEnvironment { get; set; }

        public Startup(IHostingEnvironment env)
        {
            CurrentEnvironment = env;
            var builder = new ConfigurationBuilder()
                            .SetBasePath(CurrentEnvironment.ContentRootPath)
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                            .AddJsonFile($"appsettings.{CurrentEnvironment.EnvironmentName}.json", optional: true)
                            .AddEnvironmentVariables();
            Configuration = builder.Build();

        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            services.AddDbContext<TestItContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("TestIT.Web"))
                       .AddEntityTypeConfigurations(typeof(Startup).GetTypeInfo().Assembly);
                options.UseOpenIddict();
            });
            

            services
                .AddRawRabbit(new RawRabbitOptions
                {
                    ClientConfiguration = new RawRabbitConfiguration
                {
                    Username = "guest",
                    Password = "guest",
                    VirtualHost = "/",
                    Port = 5762,
                    Hostnames = { "127.0.0.1" },
                    RequestTimeout = TimeSpan.FromSeconds(10),
                    PublishConfirmTimeout = TimeSpan.FromSeconds(10),
                    PersistentDeliveryMode = true,
                    TopologyRecovery = true,
                    AutoCloseConnection = false,
                    AutomaticRecovery = true,
                    Exchange = new GeneralExchangeConfiguration
                    {
                        AutoDelete = false,
                        Durable = true,
                        Type = ExchangeType.Topic
                    },
                    Queue = new GeneralQueueConfiguration
                    {
                        AutoDelete = false,
                        Durable = true,
                        Exclusive = false
                    },
                    RecoveryInterval = TimeSpan.FromMinutes(1),
                    GracefulShutdown = TimeSpan.FromMinutes(1),
                    RouteWithGlobalId = true,
                    Ssl = new SslOption()
                },
                    DependencyInjection = ioc => ioc.AddSingleton(LoggingFactory.ApplicationLogger),
                    Plugins = p => p
                        .UseStateMachine()
                        .UseGlobalExecutionId()
                });
            // Register the Identity services.
            services.AddIdentity<User, Role>(/*config =>
            {
                config.Cookies.ApplicationCookie.LoginPath = "/login";
                config.Cookies.ApplicationCookie.AutomaticChallenge = false;

                // if we are accessing the /api and an unauthorized request is made
                // do not redirect to the login page, but simply return "Unauthorized"
                config.Cookies.ApplicationCookie.Events = new CookieAuthenticationEvents
                {
                    OnRedirectToLogin = ctx =>
                    {
                        if (ctx.Request.Path.StartsWithSegments("/api") &&
                                                                    ctx.Response.StatusCode == (int)HttpStatusCode.OK)
                            ctx.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        else
                            ctx.Response.Redirect(ctx.RedirectUri);

                        return Task.CompletedTask;
                    }
                };
                
            }*/)
                .AddEntityFrameworkStores<TestItContext>()
                .AddDefaultTokenProviders();

            // Configure Identity to use the same JWT claims as OpenIddict instead
            // of the legacy WS-Federation claims it uses by default (ClaimTypes),
            // which saves you from doing the mapping in your authorization controller.
            services.Configure<IdentityOptions>(options =>
            {
                options.ClaimsIdentity.UserNameClaimType = OpenIdConnectConstants.Claims.Name;
                options.ClaimsIdentity.UserIdClaimType = OpenIdConnectConstants.Claims.Subject;
                //options.ClaimsIdentity.RoleClaimType = OpenIdConnectConstants.Claims.Role;
            });

            // Register the OpenIddict services.
            services.AddOpenIddict(options =>
            {
                // Register the Entity Framework stores.
                options.AddEntityFrameworkCoreStores<TestItContext>();

                // Register the ASP.NET Core MVC binder used by OpenIddict.
                // Note: if you don't call this method, you won't be able to
                // bind OpenIdConnectRequest or OpenIdConnectResponse parameters.
                options.AddMvcBinders();

                // Enable the authorization, logout, token and userinfo endpoints.
                options.EnableAuthorizationEndpoint("/connect/authorize")
                       .EnableLogoutEndpoint("/connect/logout")
                       .EnableTokenEndpoint("/connect/token")
                       .EnableUserinfoEndpoint("/api/userinfo");

                // Note: the Mvc.Client sample only uses the authorization code flow but you can enable
                // the other flows if you need to support implicit, password or client credentials.
                options.AllowPasswordFlow();
                
                // When request caching is enabled, authorization and logout requests
                // are stored in the distributed cache by OpenIddict and the user agent
                // is redirected to the same page with a single parameter (request_id).
                // This allows flowing large OpenID Connect requests even when using
                // an external authentication provider like Google, Facebook or Twitter.
                // options.EnableRequestCaching();

                // During development, you can disable the HTTPS requirement.
                if (CurrentEnvironment.IsDevelopment())
                {
                    options.DisableHttpsRequirement();
                }
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, TestItContext context)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            // Add a middleware used to validate access
            // tokens and protect the API endpoints.
            app.UseOAuthValidation();

            app.UseOpenIddict();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(CurrentEnvironment.ContentRootPath, "node_modules")),
                RequestPath = "/node_modules"
            });

            app.UseSwaggerUi(typeof(Startup).GetTypeInfo().Assembly, new SwaggerUiOwinSettings()
            {
                OperationProcessors =
                {
                    new OperationSecurityScopeProcessor("apikey")
                },
                DocumentProcessors =
                {
                    new SecurityDefinitionAppender("apikey", new SwaggerSecurityScheme
                    {
                        Type = SwaggerSecuritySchemeType.ApiKey,
                        Name = "Authorization",
                        In = SwaggerSecurityApiKeyLocation.Header
                    })
                },
                DefaultPropertyNameHandling = PropertyNameHandling.CamelCase
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                // in case multiple SPAs required.
                routes.MapSpaFallbackRoute("spa-fallback", new { controller = "home", action = "index" });

            });

             if (CurrentEnvironment.IsDevelopment())
            {
                DbInitializer.Initialize(context);
            }

        }
    }
}
