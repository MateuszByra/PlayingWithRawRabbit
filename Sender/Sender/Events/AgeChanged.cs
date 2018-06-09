using System;
using System.Collections.Generic;
using System.Text;

namespace Sender.Events
{
    [Serializable]
    public class AgeChanged
    {
        public int IntValue { get;}
        public AgeChanged(int value)
        {
            this.IntValue = value;
        }
    }
}
