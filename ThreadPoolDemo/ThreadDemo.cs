using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolDemo
{
    internal class ThreadDemo
    {
        private delegate void AddDelegeate(int a,int b);
        internal delegate void TestDelegeate(object? o);
        //public delegate void MyWaitCallBack(object? state);
        public void main()
        {
            AddDelegeate addDelegeate = new AddDelegeate(Add);
            var ar= addDelegeate.BeginInvoke(1, 3, asyncResult =>
            {
                Console.WriteLine($"Over{asyncResult.AsyncState}");

            }, "OBJ");

            addDelegeate.EndInvoke(ar);
         
        }

        public void Add(int a,int b)
        {
            Console.WriteLine(a + ", " + b);
        }

        public void Test(object? o, TestDelegeate delegeate) 
        {
            delegeate(o);
        }

        public void t()
        {
            CancellationTokenSource cancellationTokenSource= new CancellationTokenSource();
            TaskFactory taskFactory=new TaskFactory(cancellationTokenSource.Token);
            taskFactory.StartNew(()=>t1(cancellationTokenSource));
            taskFactory.StartNew(()=>t2(cancellationTokenSource));
            Console.WriteLine($"ID:{Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(3000);
            cancellationTokenSource.Cancel();
            Console.ReadLine();
            //Console.WriteLine(t0)
            //Thread.Sleep(30000);
        }

        public void t1(CancellationTokenSource cancellationTokenSource)
        {
            for (var i = 0; i < 10; i++)
            {
                if (cancellationTokenSource.IsCancellationRequested)
                {
                    break;
                }
                Console.WriteLine($"ID:{Thread.CurrentThread.ManagedThreadId}   t1:{i}");
                Thread.Sleep(500);
            }
        }

        public void t2(CancellationTokenSource cancellationTokenSource)
        {
            for (var i = 0; i < 10; i++)
            {
                if (cancellationTokenSource.IsCancellationRequested)
                {
                    break;
                }
                Console.WriteLine($"ID:{Thread.CurrentThread.ManagedThreadId}   t2:{i}");
                Thread.Sleep(500);
            }
        }

        public void t3()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            TaskFactory taskFactory = new TaskFactory(cancellationTokenSource.Token);
            taskFactory.StartNew(() => {
                for (var i = 0; i < 10; i++)
                {
                    Console.WriteLine($"ID:{Thread.CurrentThread.ManagedThreadId}   t1:{i}");
                    Thread.Sleep(1000);
                }
            });
            taskFactory.StartNew(() => {
                for (var i = 0; i < 10; i++)
                {
                    Console.WriteLine($"ID:{Thread.CurrentThread.ManagedThreadId}   t2:{i}");
                    Thread.Sleep(1000);
                }
            });
            Thread.Sleep(3000);
            cancellationTokenSource.Cancel();
        }

    }
}
