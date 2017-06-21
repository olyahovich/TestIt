using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RawRabbit;
using RawRabbit.Configuration;
using RawRabbit.Enrichers.GlobalExecutionId;
using RawRabbit.Enrichers.MessageContext;
using RawRabbit.Extensions.Client;
using RawRabbit.Instantiation;
using RawRabbit.Pipe;
using TestIT.SharedLibraries.Messages;
using ExchangeType = RawRabbit.Configuration.Exchange.ExchangeType;
using IBusClient = RawRabbit.IBusClient;
using RawRabbitFactory = RawRabbit.Instantiation.RawRabbitFactory;

namespace TestIT.WindowsService
{
    public class Program
    {
        private static IBusClient _client;
        private static Random _random;

        public static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }

        public static async Task RunAsync()
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
                    RequestTimeout = TimeSpan.FromSeconds(100),
                    PublishConfirmTimeout = TimeSpan.FromSeconds(100),
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
                Plugins = p => p
                    .UseGlobalExecutionId()
                    .UseMessageContext<TestItMessageContext>()
            };
            _client = RawRabbitFactory.CreateSingleton(options);

            
            await _client.SubscribeAsync<RequestMessage, TestItMessageContext>((requested, ctx) => ServeValuesAsync(requested, ctx));
            
        }


        private static Task ServeValuesAsync(RequestMessage message, TestItMessageContext ctx)
        {
            var pathToFile = "";
            Process p = new Process();
            p.StartInfo.FileName = message.PathToFile;
            p.Start();
            p.WaitForExit();
                Bitmap screen = new Bitmap(1920, 1080);

                //Create graphics object from bitmap
                Graphics g = Graphics.FromImage(screen);

                //Paint the screen on the bitmap
                g.CopyFromScreen(0, 0, 0, 0, screen.Size);
                g.Dispose();
                
                screen.Save("\\\\MWW-176\\Files\\screenshot.bmp");

                pathToFile = "\\\\MWW-176\\Files\\screenshot.bmp";

            p.Kill();
            return _client.PublishAsync(new ResponseMessage() { ResultPath = pathToFile });
        }

        private Bitmap Screenshot()
        {
            //Create a bitmap with the same dimensions like the screen
            Bitmap screen = new Bitmap(2000,2000);

            //Create graphics object from bitmap
            Graphics g = Graphics.FromImage(screen);

            //Paint the screen on the bitmap
            g.CopyFromScreen(2000,2000,0, 0, screen.Size);
            g.Dispose();

            //return bitmap object / screenshot
            return screen;
        }
    }
}