using System;
using System.Collections.Generic;
using System.Text;

namespace Sender.Events
{
    public class NameChanged : IMessage
    {
        public string StringValue { get; }

        public NameChanged(string value)
        {
            this.StringValue = value;
        }
    }
}
