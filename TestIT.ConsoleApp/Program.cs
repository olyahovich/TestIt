using System;
using PeterKottas.DotNetCore.WindowsService;
using RabbitMQ.Client;
using RawRabbit;
using RawRabbit.Configuration;
using RawRabbit.Enrichers.GlobalExecutionId;
using RawRabbit.Enrichers.MessageContext;
using RawRabbit.Instantiation;
using TestIT.SharedLibraries.Messages;
using ExchangeType = RawRabbit.Configuration.Exchange.ExchangeType;

namespace TestIT.WindowsService
{
    public class Program
    {
        public static IBusClient _client;

        public static void Main(string[] args)
        {
            ServiceRunner<ServiceTimer>.Run(config =>
            {
                config.SetName("TestItService");
                config.Service(serviceConfig =>
                {
                    serviceConfig.ServiceFactory((extraArguments) => new ServiceTimer());

                    serviceConfig.OnStart((service, extraParams) =>
                    {
                        var options = new RawRabbitOptions
                        {
                            ClientConfiguration = new RawRabbitConfiguration
                            {
                                Username = "admin",
                                Password = "admin",
                                VirtualHost = "/",
                                Port = 5672,
                                Hostnames = { "10.51.0.58" },
                                RequestTimeout = TimeSpan.FromSeconds(10),
                                PublishConfirmTimeout = TimeSpan.FromSeconds(30),
                                PersistentDeliveryMode = true,
                                TopologyRecovery = true,
                                AutoCloseConnection = false,
                                AutomaticRecovery = true,
                                Exchange = new GeneralExchangeConfiguration
                                {
                                    AutoDelete = true,
                                    Durable = true,
                                    Type = ExchangeType.Topic
                                },
                                Queue = new GeneralQueueConfiguration
                                {
                                    AutoDelete = true,
                                    Durable = true,
                                    Exclusive = true
                                },
                                RecoveryInterval = TimeSpan.FromMinutes(1),
                                GracefulShutdown = TimeSpan.FromMinutes(1),
                                RouteWithGlobalId = true,
                                Ssl = new SslOption()
                            },
                            Plugins = p => p
                                .UseGlobalExecutionId()
                                .UseMessageContext<TestItMessageContext>()
                        };
                        _client = RawRabbitFactory.CreateSingleton(options);
                        Console.WriteLine("Service {0} started", "TestItService");
                        service.Start();
                    });

                    serviceConfig.OnStop(service =>
                    {
                        Console.WriteLine("Service {0} stopped", "TestItService");
                        service.Stop();
                    });

                    serviceConfig.OnError(e =>
                    {
                        Console.WriteLine("Service {0} errored with exception : {1}", "TestItService", e.Message);
                    });
                });
            });
        }
    }
}