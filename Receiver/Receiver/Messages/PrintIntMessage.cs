using Receiver.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Receiver.Messages
{
    public class PrintIntMessage : MessageBase
    {
        public int IntValue { get; set; }
    }
}
