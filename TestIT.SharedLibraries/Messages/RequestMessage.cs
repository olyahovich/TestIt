using RawRabbit.Configuration.Exchange;
using RawRabbit.Enrichers.Attributes;

namespace TestIT.SharedLibraries.Messages
{
    [Exchange(Type = ExchangeType.Topic)]
    [Queue(Name = "testit.request.queue1", Durable = false)]
    [Routing(RoutingKey = "testit.routing.key")]
    public class RequestMessage
    {
        public string PathToFile { get; set; }
        public string Argument { get; set; }
    }
}
