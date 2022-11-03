using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateAndEvent.Version6
{
    class MySubscriber66
    {
        public void OnEvent(int i)
        {
            throw new Exception("Throw a Exception");
        }
    }
}
