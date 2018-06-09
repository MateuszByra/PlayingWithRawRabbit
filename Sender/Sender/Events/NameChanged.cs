using System;
using System.Collections.Generic;
using System.Text;

namespace Sender.Events
{
    [Serializable]
    public class NameChanged
    {
        public string StringValue { get; }

        public NameChanged(string value)
        {
            this.StringValue = value;
        }
    }
}
