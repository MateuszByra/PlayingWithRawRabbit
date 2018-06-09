using Receiver.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Receiver.Messages
{
    public class PrintStringMessage : MessageBase
    {
        public string StringValue { get; set; }
    }
}
