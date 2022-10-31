using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBusCore.MyEventBus
{
    public class MyPubSubEventArgs<T> : EventArgs
    {
        public T Value { get; set; }
    }
}
