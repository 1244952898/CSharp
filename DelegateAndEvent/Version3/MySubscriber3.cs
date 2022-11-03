using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateAndEvent.Version3
{
   public class MySubscriber3
    {
        public void GetNum(int count)
        {
            Console.WriteLine($"Subscriber notified: count = {0}", count);
        }
    }
}
