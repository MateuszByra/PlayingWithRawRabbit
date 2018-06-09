using System;
using System.Collections.Generic;
using System.Text;
using RawRabbit.Attributes;

namespace Receiver.Messages
{
    [Routing(RoutingKey = "string_routing_key")]
    public class PrintStringMessage
    {
        public string StringValue { get; set; }
    }
}
