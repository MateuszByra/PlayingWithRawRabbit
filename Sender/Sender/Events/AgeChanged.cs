using System;
using System.Collections.Generic;
using System.Text;
using RawRabbit.Attributes;

namespace Sender.Events
{
    [Routing(RoutingKey = "int_routing_key")]
    public class AgeChanged
    {
        public int IntValue { get;}
        public AgeChanged(int value)
        {
            this.IntValue = value;
        }
    }
}
