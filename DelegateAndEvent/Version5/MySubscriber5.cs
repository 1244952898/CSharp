using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateAndEvent.Version5
{
    public class MySubscriber5
    {
        public void OnEvent(int i)
        {
            Console.WriteLine($"{this.GetType().FullName}");
        }
    }
}
