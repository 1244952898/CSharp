using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp
{
    public class ThreadDemo
    {
        public static void Run()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.Token.Register(() => {
                Console.WriteLine($"cancellationTokenSource的Register方法0");
            });
            cancellationTokenSource.Token.Register(() => {
                Console.WriteLine($"cancellationTokenSource的Register方法1");
            });
            Console.WriteLine($"输入Token之前");
            ThreadPool.QueueUserWorkItem(x => {
                Console.WriteLine(x);
                var par=(ThreadPoolParameters)x;
                Console.WriteLine($"{par.Num}-{par.Token}");
                for (int i = 0; i < par.Num; i++)
                {
                    if (par.Token.IsCancellationRequested)
                    {
                        Console.WriteLine($"Cancel is canceled");
                        break;
                    }
                    Console.WriteLine(i);
                    Thread.Sleep(300);
                }
                Console.WriteLine($"Pool is done");
            },new ThreadPoolParameters(30, cancellationTokenSource.Token));

            Console.WriteLine($"输入danti结束任务");
            var key = Console.ReadLine();
            cancellationTokenSource.Cancel();
        }

        public static void Run1()
        {
            Task parent = new Task(()=> 
            {
                CancellationTokenSource cts = new CancellationTokenSource();
                TaskFactory<Int32> tf = new TaskFactory<Int32>(cts.Token,TaskCreationOptions.AttachedToParent,TaskContinuationOptions.ExecuteSynchronously,TaskScheduler.Default);

                var tasks = new[]
                {
                    tf.StartNew(()=>Sum(cts.Token,10000)),
                    tf.StartNew(()=>Sum(cts.Token,20000)),
                    tf.StartNew(()=>Sum(cts.Token,-1)),
                };

                for (int i = 0; i < tasks.Length; i++)
                {
                    tasks[i].ContinueWith(t => cts.Cancel(), TaskContinuationOptions.OnlyOnFaulted);
                }
                tf.ContinueWhenAll(tasks, conpleteTask => conpleteTask.Where(t => !t.IsFaulted && !t.IsCanceled).Max(t => t.Result), CancellationToken.None)
                ?.ContinueWith(t => Console.WriteLine($"Max numer is {t.Result}"),TaskContinuationOptions.ExecuteSynchronously);
            });

            parent.ContinueWith(p =>
            {
                var sb = new StringBuilder("The follow exceptions occure :" + Environment.NewLine);
                foreach (var e in p.Exception.Flatten().InnerExceptions)
                {
                    sb.AppendLine($" {e.GetType()}");
                }
                Console.WriteLine(sb.ToString());

            }, TaskContinuationOptions.OnlyOnFaulted);

            parent.Start();
        }

        private static Timer timer;
        /// <summary>
        /// Calllback Timer
        /// </summary>
        public static void Run2()
        {
            Console.WriteLine($"ThreadId:{Thread.CurrentThread.ManagedThreadId}");
            if (timer==null)
            {
                timer = new Timer(TimerCallback, "2", Timeout.Infinite, Timeout.Infinite);
            }
            timer.Change(0, Timeout.Infinite);
        }

        public static void TimerCallback(object state)
        {
            int i = Int32.Parse(state.ToString())+1;
            Console.WriteLine($"{state}  {DateTime.Now} ThreadId:{Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(100);
            timer.Change(200, Timeout.Infinite);
        }

        public static int Sum(CancellationToken ct,int m)
        {
            if (m==-1&&!ct.IsCancellationRequested)
            {
                throw new Exception("-1 exception ");
            }
            return m + m;
        }
    }
    public class ThreadPoolParameters
    {
        public int Num { get; set; }

        public CancellationToken Token { get; set; }

        public ThreadPoolParameters(int n,CancellationToken c)
        {
            Num = n;
            Token = c;
        }
    }
}
