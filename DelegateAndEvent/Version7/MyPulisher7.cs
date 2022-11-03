using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateAndEvent.Version7
{
    public class MyPulisher7
    {
        public delegate string DelegateMethodHandler(int i);
        public event DelegateMethodHandler DelegateEvent;
        public int Count { get; set; }
        public object[] DoSomethings()
        {
            if (DelegateEvent!=null)
            {
                return Program.InvokeEvent(DelegateEvent, Count++);
            }
            return null;
        }
    }
}
