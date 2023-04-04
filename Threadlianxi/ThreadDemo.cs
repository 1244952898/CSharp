using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Threadlianxi
{
    internal class ThreadDemo
    {
        public static void main()
        {
            Thread thread = new Thread(Run);
            thread.Start();
            Thread thread1 = new Thread(SleepRun);
            thread1.Start();
            Run();
            thread1.Join();
            Console.WriteLine("线程结束");
        }

        public static void Run()
        {
            Console.WriteLine($"ManagedThreadId is :{Thread.CurrentThread.ManagedThreadId} Starting...");
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine($"ManagedThreadId is :{Thread.CurrentThread.ManagedThreadId} num is {i}");
            }
        }

        public static void SleepRun()
        {
            Console.WriteLine($"SleepRun-ManagedThreadId is :{Thread.CurrentThread.ManagedThreadId} Starting...");
            for (int i = 1; i < 10; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine($"SleepRun-ManagedThreadId is :{Thread.CurrentThread.ManagedThreadId} num is {i}");
            }
        }
    }
}
