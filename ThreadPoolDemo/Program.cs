using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            
            ThreadPool.QueueUserWorkItem(a =>
            {
                Console.WriteLine(1);
                Console.WriteLine(1);
                Console.WriteLine(1);
                Console.WriteLine(1);
            });
            
            Task.Run(() => Console.WriteLine(1111));
            //TaskCompletionSource<bool> tcs = new();
            Thread.Sleep(1000);
            //Interlocked.CompareExchange(ref numOutstandingThreadRequests, num + 1, num);
            var numOutstandingThreadRequests = 3;
            int a = Interlocked.CompareExchange(ref numOutstandingThreadRequests, 333, 3);
            Console.WriteLine(a);
        }
        //static void test(ref int a)
        //{
        //    a += 100;
        //    Console.WriteLine("3:" + a);
        //}
    }
}
