using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DelegateAndEvent.Version7
{
    class MySubscriber777
    {
        public string OnEvent(int i)
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
            return $"{this.GetType().FullName}+ {i.ToString()} Sleep 2s";
        }
    }
}
