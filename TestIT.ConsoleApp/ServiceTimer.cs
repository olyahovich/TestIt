using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.PlatformAbstractions;
using PeterKottas.DotNetCore.WindowsService.Base;
using PeterKottas.DotNetCore.WindowsService.Interfaces;
using RabbitMQ.Client;
using RawRabbit;
using RawRabbit.Configuration;
using RawRabbit.Enrichers.GlobalExecutionId;
using RawRabbit.Enrichers.MessageContext;
using RawRabbit.Instantiation;
using RawRabbit.Pipe;
using TestIT.SharedLibraries.Messages;
using ExchangeType = RawRabbit.Configuration.Exchange.ExchangeType;

namespace TestIT.WindowsService
{
    public class ServiceTimer: IMicroService
    {
        private string fileName = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "log.txt");
        public void Start()
        {
            RunAsync().GetAwaiter().GetResult();
            Console.WriteLine("I started");
            File.AppendAllText(fileName, "Started\n");
        }

        public void Stop()
        {
            File.AppendAllText(fileName, "Stopped\n");
            Console.WriteLine("I stopped");
        }

        public static async Task RunAsync()
        {
            await Program._client.SubscribeAsync<RequestMessage>(recieved =>
                {
                    ServeValuesAsync(recieved);
                return Task.FromResult(true);
            }, ctx => ctx
                .UseConsumerConfiguration(cfg => cfg
                    .OnDeclaredExchange(e => e
                        .WithName("custom_exchange")
                    ))
                );
        }


        private static Task ServeValuesAsync(RequestMessage message)
        {
            var pathToFile = "";
            Process p = new Process();
            p.StartInfo.FileName = "cmd";
            p.StartInfo.Arguments = "/C copy " + message.PathToFile + " " + PlatformServices.Default.Application.ApplicationBasePath;
            p.Start();
            File.AppendAllText(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "log.txt"), string.Format("File is copied\n", DateTime.Now.ToString("o")));
            Thread.Sleep(15000);
            Process p2 = new Process();
            p2.StartInfo.CreateNoWindow = true;
            p2.StartInfo.FileName = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, message.Argument);
            p2.Start();
            Boolean found = false;
            while (!found)
            {
                foreach (Process clsProcess in Process.GetProcesses())
                    if (clsProcess.ProcessName == Path.GetFileNameWithoutExtension(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, message.Argument)))
                        found = true;

                Thread.Sleep(1000);

            }
            File.AppendAllText(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "log.txt"), string.Format("File is run\n", DateTime.Now.ToString("o")));

            Bitmap screen = new Bitmap(1920, 1080);

            //Create graphics object from bitmap
            Graphics g = Graphics.FromImage(screen);

            Thread.Sleep(1000);
            //Paint the screen on the bitmap
            g.CopyFromScreen(0, 0, 0, 0, screen.Size);
            File.AppendAllText(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "log.txt"), string.Format("Screenshot is made\n", DateTime.Now.ToString("o")));

            g.Dispose();

            screen.Save(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "screenshot.bmp"));

            pathToFile = "screenshot.bmp";

            File.AppendAllText(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "log.txt"), string.Format("Command Executed\n", DateTime.Now.ToString("o")));
            p2.Kill();
            File.AppendAllText(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "log.txt"), string.Format("Process is Killed\n", DateTime.Now.ToString("o")));
            p.StartInfo.FileName = "cmd";
            p.StartInfo.Arguments = "/C copy " + "screenshot.bmp" + " " + "\\\\MWW-176\\Files\\";
            p.Start();
            File.AppendAllText(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "log.txt"), string.Format("Screenshot is copied\n", DateTime.Now.ToString("o")));
            Thread.Sleep(15000);

            return Program._client.PublishAsync(new ResponseMessage() { ResultPath = pathToFile }, ctx => ctx.UsePublisherConfiguration(cfg =>
                cfg.OnExchange("custom_exchange")
                   .WithProperties(c => c.DeliveryMode = 1)));
        }

        private Bitmap Screenshot()
        {
            //Create a bitmap with the same dimensions like the screen
            Bitmap screen = new Bitmap(2000, 2000);

            //Create graphics object from bitmap
            Graphics g = Graphics.FromImage(screen);

            //Paint the screen on the bitmap
            g.CopyFromScreen(2000, 2000, 0, 0, screen.Size);
            g.Dispose();

            //return bitmap object / screenshot
            return screen;
        }
    }
}
