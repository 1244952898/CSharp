using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Threadlianxi
{
    internal class CountdownEventDemo
    {
        private CountdownEvent countdown=new CountdownEvent(2);
        public void M()
        {
            Thread thread0 = new Thread(() =>
            {
                P(2000);
            });
            thread0.Start();

            Thread thread1 = new Thread(() =>
            {
                P(3000);
            });
            thread1.Start();

            Console.WriteLine($"任务开始");
            countdown.Wait();
            Console.WriteLine($"任务结束");
            countdown.Dispose();
        }

        public void P(int m)
        {
            Thread.Sleep(m);
            Console.WriteLine($"开始任务---{Thread.CurrentThread.ManagedThreadId}");
            countdown.Signal();
            Console.WriteLine($"结束任务---{Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
