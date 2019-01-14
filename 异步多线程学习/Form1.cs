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

        private void btnPara_Click(object sender, EventArgs e)
        {
            Console.WriteLine("--------- btnPara_Click开始");

            for (int i = 0; i < 10; i++)
            {
                ParameterizedThreadStart parameterizedThreadStart = x => {
                    Thread.Sleep(100);
                    Console.WriteLine("+++++++++++开始btnCalBack_Click线程 {0}", Thread.CurrentThread.ManagedThreadId);
                    Console.WriteLine("+++++++++++PbtnCalBack_Click输出 {0}", x);
                };
                ThreadExtesion thread = new ThreadExtesion();
                Func<string> ss = ()=> {return "a";};

                string s= thread.ThreadCallBack(parameterizedThreadStart, ss, i);
                Console.WriteLine("+++++++++++带有返回值 {0}", s);
            }
            
            Console.WriteLine("--------- btnPara_Click结束");
        }

        private void btnpool_Click(object sender, EventArgs e)
        {
            Console.WriteLine("--------- btnpool_Click开始");

            ManualResetEvent manualResetEvent = new ManualResetEvent(false);
            for (int i = 0; i < 10; i++)
            {
                WaitCallback waitCallback = x => {
                    Thread.Sleep(100);
                   
                    Console.WriteLine("+++++++++++开始btnCalBack_Click线程 {0}", Thread.CurrentThread.ManagedThreadId);
                    Console.WriteLine(x);
                    manualResetEvent.Set();
                };
                ThreadPool.QueueUserWorkItem(waitCallback,i);
            }

            Console.WriteLine("do something else");
            Console.WriteLine("do something else");
            Console.WriteLine("do something else");
            manualResetEvent.WaitOne();
            new Action(() => {
                Thread.Sleep(3000);
                Console.WriteLine("改变新哈量ManualResetEvent");
                manualResetEvent.Set();
            }).BeginInvoke(null,null);
            manualResetEvent.WaitOne();
            Console.WriteLine(" manualResetEvent.WaitOne();");

            manualResetEvent.Reset();
            new Action(() => {
                Thread.Sleep(2000);
                Console.WriteLine("改变新哈量ManualResetEvent");
                manualResetEvent.Set();
            }).BeginInvoke(null, null);
            manualResetEvent.WaitOne();
            Console.WriteLine("再次 manualResetEvent.WaitOne();");



            Console.WriteLine("--------- btnpool_Click结束");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("开始==============");
            ManualResetEvent mre = new ManualResetEvent(false);
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(x =>
                {
                    Thread.Sleep(500);
                    Console.WriteLine("+++++++++++线程Id={0} ,属于{1}", Thread.CurrentThread.ManagedThreadId,x);
                }), i);
            }
            while (true) {
                int maxWorkerThreads, workerThreads;
                int portThreads;
                ThreadPool.GetMaxThreads(out maxWorkerThreads, out portThreads);
                ThreadPool.GetAvailableThreads(out workerThreads, out portThreads);
                if (maxWorkerThreads== workerThreads)
                {
                    break;
                }
            }
            
            Console.WriteLine("结束==============");
        }

        static object lockObj=new object();

        /// <summary>
        /// 错误，有问题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("开始==============");
            int runingThread = 10;
            for (int i = 0; i < runingThread; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(x =>
                {
                    Thread.Sleep(500);
                    Monitor.Pulse(lockObj);
                    Console.WriteLine("+++++++++++线程Id={0} ,属于{1}", Thread.CurrentThread.ManagedThreadId, x);
                }), i);
            }
            lock (lockObj) {
                while (runingThread > 0)
                {
                    Monitor.Wait(lockObj);
                }
            }
            
            Console.WriteLine("结束==============");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Console.WriteLine("开始==============");
            int runingThread = 10;
            //List<ManualResetEvent> mreList = new List<ManualResetEvent>();
            ManualResetEvent[] _ManualEvents = new ManualResetEvent[10];
            for (int i = 0; i < runingThread; i++)
            {
                //mreList.Add(new ManualResetEvent(false));
                _ManualEvents[i] = new ManualResetEvent(false);
                ThreadPool.QueueUserWorkItem(new WaitCallback(x =>
                {
                    Thread.Sleep(500);
                    Console.WriteLine("+++++++++++线程Id={0} ,属于{1}", Thread.CurrentThread.ManagedThreadId, x);
                    _ManualEvents[Convert.ToInt32(x)].Set();
                }), i);
            }

            //WaitHandle.WaitAll(mreList.ToArray());
            WaitHandle.WaitAll(_ManualEvents);//注释掉[STAThread]

            Console.WriteLine("结束==============");
        }

        static int count = 10;
        private void button4_Click(object sender, EventArgs e)
        {
            
            Console.WriteLine("开始==============");
            int runingThread = 10;
            //List<ManualResetEvent> mreList = new List<ManualResetEvent>();
            ManualResetEvent _ManualEvents = new ManualResetEvent(false);
            for (int i = 0; i < runingThread; i++)
            {
                //mreList.Add(new ManualResetEvent(false));
                ThreadPool.QueueUserWorkItem(new WaitCallback(x =>
                {
                    Thread.Sleep(500);
                    Console.WriteLine("+++++++++++线程Id={0} ,属于{1}", Thread.CurrentThread.ManagedThreadId, x);
                    count--;
                    if (count==0)
                    {
                        _ManualEvents.Set();
                    }
                    
                }), i);
            }

            _ManualEvents.WaitOne();

            Console.WriteLine("结束==============");
        }
    }
}


   
