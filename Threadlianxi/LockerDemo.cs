using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threadlianxi
{
    internal class LockerDemo
    {
        public static void M()
        {
            {
                Thread t0 = new Thread(CountBase.Add);
                Thread t1 = new Thread(CountBase.Add);
                Thread t2 = new Thread(CountBase.Add);
                t0.Start();
                t1.Start();
                t2.Start();
                t0.Join();
                t1.Join();
                t2.Join();
                Console.WriteLine(CountBase.Count);
            }

            {
                Thread t0 = new Thread(CountWitLock.Add);
                Thread t1 = new Thread(CountWitLock.Add);
                Thread t2 = new Thread(CountWitLock.Add);
                t0.Start();
                t1.Start();
                t2.Start();
                t0.Join();
                t1.Join();
                t2.Join();
                Console.WriteLine(CountWitLock.Count);
            }
            var t = Task.Delay(1000);
            var awt= t.GetAwaiter();
            //awt.
        }
    }

    public class CountBase
    {
        public static int Count { get; set; }
        public static void Add()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(200);
                Count++;
                Console.WriteLine($"CountBase:{Count}");
            }
        }
    }

    public class CountWitLock
    {
        Mutex mutex=new Mutex();
        SemaphoreSlim semaphore=new SemaphoreSlim(1);
        public static int Count { get; set; }
        private static object locker = new object();
        public static void Add()
        {
            lock (locker)
            {
                //Monitor.Enter(locker);
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(200);
                    Count++;
                    Console.WriteLine($"CountWitLock:{Count}");
                }
                //Monitor.Exit(locker);
            }

            //Interlocked.
        }
    }

}
