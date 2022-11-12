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
