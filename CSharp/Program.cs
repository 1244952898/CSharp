using Aliyun.OSS;
using Apache.NMS.ActiveMQ.Threads;
using CSharp.Emit;
using CSharpCore.Models;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            YeildTest yeildTest = new YeildTest();
            foreach (var i in yeildTest.YieldTest1())
            {
            }
            //NPOIDemo demo = new NPOIDemo();
            //demo.Test();

            //var c = TestEnum.a | TestEnum.b | TestEnum.c;
            //EmitDemo.Create(c);

            Console.WriteLine(2222222);

            Console.ReadKey();
        }

        static Task IterateAsync(IEnumerable<Task> tasks)
        {
            var tcs = new TaskCompletionSource<int>();

            IEnumerator<Task> e = tasks.GetEnumerator();

            void Process()
            {
                try
                {
                    if (e.MoveNext())
                    {
                        e.Current.ContinueWith(t => Process());
                        return;
                    }
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                    return;
                }
                tcs.SetResult(1);
            };
            Process();

            return tcs.Task;
        }
    }
}
