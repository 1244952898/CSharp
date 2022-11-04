using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DelegateAndEvent.Version8
{
    public delegate int AddDelegate(int x, int y);

    public class Calculator0
    {
        public int Add(int x, int y)
        {
            if (Thread.CurrentThread.IsThreadPoolThread)
            {
                Thread.CurrentThread.Name = $"Thread Pool {Thread.CurrentThread.ManagedThreadId}";
            }

            for (var i = 1; i <= 2; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(i));
                Console.WriteLine("{0}: Add executed {1} second(s).",
                    Thread.CurrentThread.Name, i);
            }

            Console.WriteLine("Method complete!");
            return x + y;
        }
    }
}
