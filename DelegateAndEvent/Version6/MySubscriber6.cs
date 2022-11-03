using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateAndEvent.Version6
{
    public class MySubscriber6
    {
        public void OnEvent(int i)
        {
            Console.WriteLine($"{this.GetType().FullName}+ {i.ToString()}");
        }
    }
}
