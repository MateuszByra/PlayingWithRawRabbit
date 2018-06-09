using System;
using System.Collections.Generic;
using System.Text;
using RawRabbit.Attributes;

namespace Receiver.Messages
{
    [Routing(RoutingKey = "int_routing_key")]
    public class PrintIntMessage
    {
        public int IntValue { get; set; }
    }
}
