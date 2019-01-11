using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static 异步多线程学习.ThreadExtesion;
namespace 异步多线程学习
{
  
    public partial class Form1 : Form
    {
        public delegate void doSomeMethodDelegate(string name);
        //  public event doSomeDelegate event;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Async_Click(object sender, EventArgs e)
        {
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++btn_Async_Click {0} 开始", Thread.CurrentThread.ManagedThreadId);

          
            doSomeMethodDelegate doSomeMethod = new doSomeMethodDelegate(DoSomeThing);

            IAsyncResult asyncResult = null;

            AsyncCallback asyncCallback = b => {
                Console.WriteLine(asyncResult.Equals(b));
                Console.WriteLine(b.AsyncState);
                Console.WriteLine("回调函数！");
            };
            
           //asyncResult = doSomeMethod.BeginInvoke("btn_Async_Click", asyncCallback, "abcdefg");
            //asyncResult = doSomeMethod.BeginInvoke("btn_Async_Click", x => {
            //    Console.WriteLine(x.AsyncState);
            //    Console.WriteLine("回调函数！");
            //}, "abcdefg");

            //int i = 1;
            //while (!asyncResult.IsCompleted)
            //{
            //    Console.WriteLine("+++++++++++正在计算中！++++++++++ + 已经完成 {0}", 10 * i++);
            //    Thread.Sleep(100);
            //}

            //asyncResult.AsyncWaitHandle.WaitOne();
            //asyncResult.AsyncWaitHandle.WaitOne(100);
            //asyncResult.AsyncWaitHandle.WaitOne(1000);

            //doSomeMethod.EndInvoke(asyncResult);

            Func<int, string> func = z => {
                DoSomeThing("btn_Async_Click");
                return "2017----";
            } ;
            asyncResult = func.BeginInvoke(DateTime.Now.Millisecond, a =>
            {
                Console.WriteLine(a.AsyncState);
                Console.WriteLine("这里是回调函数 {0}", Thread.CurrentThread.ManagedThreadId);
            }, "AlwaysOnline");

            string sresult = func.EndInvoke(asyncResult);

            //ThreadPool.QueueUserWorkItem(x => { });
            //ManualResetEvent manualResetEvent = new ManualResetEvent(false);
            //manualResetEvent.Set();
            //manualResetEvent.Reset();
            TaskFactory taskFactory = new TaskFactory();
            taskFactory.ContinueWhenAll(new Task[3], x0 => { });
            Action<string> action = x3 => { Console.WriteLine("{0}", x3); };
            Action<string> action1 =x1=> DoSomeThing("a");

            Func<string,int> funccc = x2 => {
                Console.WriteLine("{0}", x2);
                return 3;
            };
            int x = funccc("ab");

            Parallel.Invoke();
            Parallel.ForEach(new string[] { "a" }, (y,state) => {
                Console.Write(y);
                state.Break();
            });

            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.MaxDegreeOfParallelism = 5;

            //Parallel.For<string>()
            CancellationTokenSource cts = new CancellationTokenSource();
            //cts.Token;
            cts.Cancel();
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++btn_Async_Click {0} 结束", Thread.CurrentThread.ManagedThreadId);

        }

        private void btnFor_Click(object sender, EventArgs e)
        {
            //List<Person> pers = new List<Person>();
            for (int i = 0; i < 10; i++)
            {
                Person p = new Person();
                TaskFactory taskFactory = new TaskFactory();
                int k = i;
                Task task = taskFactory.StartNew(() =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine(k + "  ManagedThreadId" + Thread.CurrentThread.ManagedThreadId);
                });

                //p.Age = i;
                //Action<Person> action = x => {
                //    Thread.Sleep(1000);
                //    Console.WriteLine("Person :"+x.Age + "  ManagedThreadId" + Thread.CurrentThread.ManagedThreadId);
                //};
                //action.BeginInvoke(p,null,null);
            }
         
            
        }
        private void DoSomeThing(string name)
        {

            Console.WriteLine("++++++++++++++++++++++++++++++++++++++DoSomeThing {0} 开始", Thread.CurrentThread.ManagedThreadId);

            long result = 0;
            for (int i = 0; i < 1000000000; i++)
            {
                result += i;
            }
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++DoSomeThing {0} 结束", Thread.CurrentThread.ManagedThreadId);
        }

        private void btnAsyc_Click(object sender, EventArgs e)
        {
           btnAsycClick();
        } 

        private async Task btnAsycClick() {
            Console.WriteLine("++btnAsyc {0} 开始", Thread.CurrentThread.ManagedThreadId);
            Task task = new Task(() => {
                Console.WriteLine("Task{0} 开始", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(1000);
                Console.WriteLine("Task {0} 结束", Thread.CurrentThread.ManagedThreadId);
            });
            task.Start();
            Console.WriteLine("++btnAsyc {0} 结束", Thread.CurrentThread.ManagedThreadId);

        }

        private void btnThread_Click(object sender, EventArgs e)
        {
            Console.WriteLine("--------- btnThread_Click开始");

            for (int i = 0; i < 10; i++)
            {
                ThreadStart threadStart = () => {
                    Thread.Sleep(100);
                    Console.WriteLine("+++++++++++开始线程ThreadStart {0}", Thread.CurrentThread.ManagedThreadId);

                };
                Thread thread = new Thread(threadStart);
                thread.Start();

                ParameterizedThreadStart parameterizedThreadStart =x=> {
                    Thread.Sleep(100);
                    Console.WriteLine("+++++++++++开始线程ParameterizedThreadStart {0}", Thread.CurrentThread.ManagedThreadId);
                    Console.WriteLine("+++++++++++ParameterizedThreadStart输出 {0}",x);
                };

                Thread threadp = new Thread(parameterizedThreadStart);
                threadp.Start(i);
            }

            Console.WriteLine("--------- btnThread_Click结束");
        }

        private void btnCalBack_Click(object sender, EventArgs e)
        {
            Console.WriteLine("--------- btnCalBack_Click");

            for (int i = 0; i < 10; i++)
            {
                ParameterizedThreadStart parameterizedThreadStart = x => {
                    Thread.Sleep(100);
                    Console.WriteLine("+++++++++++开始btnCalBack_Click线程 {0}", Thread.CurrentThread.ManagedThreadId);
                    Console.WriteLine("+++++++++++PbtnCalBack_Click输出 {0}", x);
                };
                ThreadExtesion thread = new ThreadExtesion();
                thread.ThreadCallBack(parameterizedThreadStart, () =>
                {
                    Console.WriteLine("回调方法");
                },i);
                
            }

            Console.WriteLine("--------- btnCalBack_Click");
        }
    }
}


   
