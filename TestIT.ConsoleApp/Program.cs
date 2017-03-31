using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RawRabbit;
using RawRabbit.Configuration;
using RawRabbit.Enrichers.GlobalExecutionId;
using RawRabbit.Enrichers.MessageContext;
using RawRabbit.Enrichers.MessageContext.Context;
using RawRabbit.vNext;
using RawRabbit.vNext.Pipe;
using TestIT.Messages;
using ExchangeType = RawRabbit.Configuration.Exchange.ExchangeType;

namespace TestIT.ConsoleApp
{
    public class Program
    {
        private static IBusClient _client;

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
                Plugins = p => p
                    .UseGlobalExecutionId()
                    .UseMessageContext<MessageContext>()
            };
            _client = RawRabbitFactory.CreateSingleton(options);

            
            await _client.SubscribeAsync<ValuesRequested, MessageContext>((requested, ctx) => ServeValuesAsync(requested, ctx));
            await _client.RespondAsync<ValueRequest, ValueResponse>(request => SendValuesThoughRpcAsync(request));
        }

        private static Task<ValueResponse> SendValuesThoughRpcAsync(ValueRequest request)
        {
            return Task.FromResult(new ValueResponse
            {
                Value = $"value{request.Value}"
            });
        }

        private static Task ServeValuesAsync(ValuesRequested message, MessageContext ctx)
        {
            var values = new List<string>();
            for (var i = 0; i < message.NumberOfValues; i++)
            {
                values.Add($"value{i}");
            }
            return _client.PublishAsync(new ValuesCalculated { Values = values });
        }
    }
}