using System;
using System.Collections.Generic;
using System.Text;
using RawRabbit.Attributes;

namespace Sender.Events
{
    [Routing(RoutingKey = "string_routing_key")]
    public class NameChanged
    {
        public string StringValue { get; }

        public NameChanged(string value)
        {
            this.StringValue = value;
        }
    }
}
