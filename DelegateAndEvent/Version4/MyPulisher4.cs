using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateAndEvent.Version4
{
    public class MyPulisher4
    {
        public delegate string MethodDelegateHandler(int i);

        public event MethodDelegateHandler MethodEvent;
        public int Count { get; set; }

        public List<string> DoSomethings()
        {
            Console.WriteLine($"DoSomethings {Count++}");
            var result = new List<string>();

            var delegates = MethodEvent.GetInvocationList();
            foreach (var dl in delegates)
            {
                var d = (MethodDelegateHandler)dl;
                result.Add(d(Count));
            }
            return result;
        }
    }
}
