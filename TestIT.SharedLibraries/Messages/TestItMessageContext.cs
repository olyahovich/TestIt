using System;
using RawRabbit.Enrichers.MessageContext.Context;

namespace TestIT.SharedLibraries.Messages
{
    public class TestItMessageContext: IMessageContext
    {
        public string CustomProperty { get; set; }
        public ulong DeliveryTag { get; set; }
        public Guid GlobalRequestId { get; set; }
    }
}
