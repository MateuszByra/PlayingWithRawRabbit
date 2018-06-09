using System;
using System.Collections.Generic;
using System.Text;

namespace Sender.Events
{
    public class AgeChanged : IMessage
    {
        public int IntValue { get;}
        public AgeChanged(int value)
        {
            this.IntValue = value;
        }
    }
}
