using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Threadlianxi
{
    internal class SemaphoreSlimDemo
    {
        SemaphoreSlim semaphoreSlim = new SemaphoreSlim(2);
        AutoResetEvent AutoResetEvent=new AutoResetEvent(false);
        ManualResetEvent ManualResetEventMan=new ManualResetEvent(false);

        public void M()
        {
            Thread t0 = new Thread(S);
            t0.Start();

            Thread t1 = new Thread(S);
            t1.Start();

            Thread t2 = new Thread(S);
            t2.Start();

            Thread t3 = new Thread(S);
            t3.Start();

            Console.WriteLine($"Thread.Sleep(3000);");
            Thread.Sleep(3000);
            semaphoreSlim.Release(1);

        }

        public void S() {

            Console.WriteLine($"当前ID:{Thread.CurrentThread.ManagedThreadId} 运行开始");
            semaphoreSlim.Wait();
            Console.WriteLine($"当前ID:{Thread.CurrentThread.ManagedThreadId} 运行结束");
        }
    }
}
