using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateAndEvent.Version4
{
    public class MySubscriber4
    {
        public string OnEvent(int i)
        {
            return i.ToString();
        }
    }
}
