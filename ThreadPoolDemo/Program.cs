using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolDemo
{
    class Program
    {
        static async void Main(string[] args)
        {
            //int i=0;
            //Timer timer = new Timer(state =>
            //{
            //    Console.WriteLine($"状态输入：{state},{i++}");
            //},"abc",0,1000);
            //Console.ReadLine();

            Thread thread = new Thread(() => {
                Console.WriteLine(111111111);
                Thread.Sleep(1000);
                Console.WriteLine(222222222);
            });

            //Thread thread1 = new Thread(() => {
            //    Console.WriteLine(33333);
            //    thread.Join();
            //    Console.WriteLine(44444444);
            //});
            //thread1.Start();
            //thread.Start();
            //Console.ReadLine();

            //var t = Task.Run(() =>
            //{
            //    int k = 1;
            //    return k + 1;
            //});


            //thread.Suspend();
            //thread.Resume();
            // var lst = new List<int>();
            // for (int i = 0; i < 100; i++)
            // {
            //     lst.Add(i);
            // }
            // var prl = lst.AsParallel();

            // ConcurrentQueue<string> strs = new ConcurrentQueue<string>();
            // CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            // cancellationTokenSource.Token.Register(() =>
            // {
            //     Console.WriteLine("被取消了");
            // });
            // Console.WriteLine($"当前主进程是{Thread.CurrentThread.ManagedThreadId}");
            // Task t = Task.Factory.StartNew(() =>
            // {
            //     try
            //     {
            //         prl
            //.WithDegreeOfParallelism(2)
            //.WithCancellation(cancellationTokenSource.Token)
            //.ForAll((i) =>
            //{
            //    Thread.Sleep(50);
            //    Console.WriteLine($"当前进程是{Thread.CurrentThread.ManagedThreadId}，数字是{i}");
            //    strs.Enqueue($"当前进程是{Thread.CurrentThread.ManagedThreadId}，数字是{i}");
            //});
            //     }
            //     catch (Exception)
            //     {

            //         throw;
            //     }

            // });

            // Console.WriteLine($"结果是：{string.Join(',', strs.ToArray())} shu：{strs.Count}");
            // Thread.Sleep(10);
            // cancellationTokenSource.Cancel();
            // t.Wait();
            // Console.ReadLine();

            //ConcurrentQueue<int> ints= new ConcurrentQueue<int>();
            //CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            //var iss = new int[] { 11, 22, 33, 44, 55, 66 };
            //Parallel.ForEach(iss, () =>
            //{
            //    Console.WriteLine($"Init");
            //    return 123456;
            //}, (source, state, l, local) =>
            //{
            //    Console.WriteLine($"Body:{source}-{state.ToString()}-{l}-{local}");
            //    return local;
            //}, local =>
            //{
            //    Console.WriteLine($"Finally:{local}");
            //});
            //Console.ReadLine();











            //Task t = new Task(() => {
            //    for (int i = 0; i < 20; i++)
            //    {
            //        cancellationTokenSource.Token.ThrowIfCancellationRequested();
            //        Thread.Sleep(100);
            //        ints.Enqueue(i);
            //    }
            //},cancellationTokenSource.Token);

            //t.Start();
            //Thread.Sleep(500);
            //cancellationTokenSource.Cancel();
            //try
            //{
            //    t.Wait();
            //}
            //catch (Exception ex)
            //{

            //}
            //finally {
            //    Console.WriteLine($"结果是：{string.Join(',', ints.ToArray())} 是否是：{t.IsCanceled}");
            //}









            //ThreadDemo threadDemo = new ThreadDemo();
            //threadDemo.t();

            //CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            //Task t = new Task(() =>
            //{
            //    for (int i = 0; i < 1000; i++)
            //    {
            //        if (cancellationTokenSource.IsCancellationRequested)
            //        {
            //            break;
            //        }
            //        Console.WriteLine(i);
            //        Thread.Sleep(1000);
            //    }
            //},cancellationTokenSource.Token);
            //t.Start();
            //Thread.Sleep(5000);
            //cancellationTokenSource.Cancel();
            //Console.ReadLine();
            //TaskFactory taskFactory = new TaskFactory(cancellationTokenSource.Token);
            //taskFactory.StartNew(()=>{
            //    for (var i = 0; i < 10; i++)
            //    {
            //        Console.WriteLine($"ID:{Thread.CurrentThread.ManagedThreadId}   t1:{i}");
            //        Thread.Sleep(1000);
            //    }
            //});
            //taskFactory.StartNew(() => {
            //    for (var i = 0; i < 10; i++)
            //    {
            //        Console.WriteLine($"ID:{Thread.CurrentThread.ManagedThreadId}   t2:{i}");
            //        Thread.Sleep(1000);
            //    }
            //});
            //Thread.Sleep(3000);
            //cancellationTokenSource.Cancel();
            //Task t0 = Task.Run(() =>
            //{
            //    for (int i = 0; i < 1000; i++)
            //    {
            //        Console.WriteLine(i);
            //        Thread.Sleep(1000);
            //    }
            //}, cancellationTokenSource.Token);

            //Task t1 = Task.Run(() =>
            //{
            //    for (int i = 0; i < 1000; i++)
            //    {
            //        Console.WriteLine(i);
            //        Thread.Sleep(1000);
            //    }
            //}, cancellationTokenSource.Token);
            //Thread.Sleep(3000);
            //cancellationTokenSource.Cancel();


            ////
            //cancellationTokenSource.Token.Register(() => { Console.WriteLine("cancellationTokenSource.Token.Register"); });
            //Task t = new Task(() =>task(cancellationTokenSource.Token,1000), cancellationTokenSource.Token);

            //t.Start();
            //Thread.Sleep(5000);
            //cancellationTokenSource.Cancel();


            //CancellationToken cancellation = new CancellationToken();
            //ThreadPool.QueueUserWorkItem(call=>pool(cancellation,1111));

            //t.Wait();

            //int? a = Task.CurrentId;
            //ThreadPool.QueueUserWorkItem(a =>
            //{
            //    Console.WriteLine(1);
            //    Console.WriteLine(1);
            //    Console.WriteLine(1);
            //    Console.WriteLine(1);
            //});
            //Task task = Task.Run(() =>
            //{
            //    Console.WriteLine(1);
            //});
            //Task.Run(() => Console.WriteLine(1111));
            //task.Exception.InnerExceptions?.ToList().ForEach(x => Console.WriteLine(x));
            ////TaskCompletionSource<bool> tcs = new();

            ////Interlocked.CompareExchange(ref numOutstandingThreadRequests, num + 1, num);
            //var numOutstandingThreadRequests = 3;
            //int a = Interlocked.CompareExchange(ref numOutstandingThreadRequests, 333, 3);
            //Console.WriteLine(a);



            //threadDemo.Test(1, obj => pool(cancellationTokenSource.Token, 111));

        }
        //static void test(ref int a)
        //{
        //    a += 100;
        //    Console.WriteLine("3:" + a);
        //}
        static int task(CancellationToken cancellationToken, int a)
        {
            int i = 0;
            cancellationToken.ThrowIfCancellationRequested();
            for (; i < a; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(500);
            }
            return i;
        }
        static int pool(CancellationToken cancellationToken,int a)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine("Cancel");
            }
            else
            {
                Console.WriteLine(a);
            }
            return a;
        }
    }

    
}
