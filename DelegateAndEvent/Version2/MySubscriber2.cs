using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateAndEvent.Version2
{
   public class MySubscriber2
    {
        public void GetNum(int count)
        {
            Console.WriteLine($"Subscriber notified: count = {0}", count);
        }
    }
}
