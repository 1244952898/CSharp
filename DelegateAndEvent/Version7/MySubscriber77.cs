using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DelegateAndEvent.Version7
{
    class MySubscriber77
    {
        public string OnEvent(int i)
        {
            return $"{this.GetType().FullName}+ {i.ToString()}";
        }
    }
}
