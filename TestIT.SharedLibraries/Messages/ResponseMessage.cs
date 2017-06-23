using RawRabbit.Configuration.Exchange;
using RawRabbit.Enrichers.Attributes;

namespace TestIT.SharedLibraries.Messages
{
        [Exchange(Type = ExchangeType.Topic)]
        [Queue(Name = "testit.request.queue1", Durable = false)]
        [Routing(RoutingKey = "testit.routing.key")]
    public class ResponseMessage
    {

        public string ResultPath { get; set; }
        public string Result { get; set; }
    }
}
