using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DelegateAndEvent.Version7
{
   public class MySubscriber7
    {
        public string OnEvent(int i)
        {
            Thread.Sleep(TimeSpan.FromSeconds(3));
            return $"{this.GetType().FullName}+ {i.ToString()} Sleep 3s";
        }
    }
}
