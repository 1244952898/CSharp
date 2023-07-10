using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
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

            asyncResult = doSomeMethod.BeginInvoke("btn_Async_Click", asyncCallback, "abcdefg");
            asyncResult = doSomeMethod.BeginInvoke("btn_Async_Click", xx =>
            {
                Console.WriteLine(xx.AsyncState);
                Console.WriteLine("回调函数！");
            }, "abcdefg");

            int i = 1;
            while (!asyncResult.IsCompleted)
            {
                Console.WriteLine("+++++++++++正在计算中！++++++++++ + 已经完成 {0}", 10 * i++);
                Thread.Sleep(100);
            }

            asyncResult.AsyncWaitHandle.WaitOne();
            asyncResult.AsyncWaitHandle.WaitOne(100);
            asyncResult.AsyncWaitHandle.WaitOne(1000);

            doSomeMethod.EndInvoke(asyncResult);

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
           //btnAsycClick();
        } 

        //private async Task btnAsycClick() {
        //    Console.WriteLine("++btnAsyc {0} 开始", Thread.CurrentThread.ManagedThreadId);
        //    Task task = new Task(() => {
        //        Console.WriteLine("Task{0} 开始", Thread.CurrentThread.ManagedThreadId);
        //        Thread.Sleep(1000);
        //        Console.WriteLine("Task {0} 结束", Thread.CurrentThread.ManagedThreadId);
        //    });
        //    task.Start();
        //    Console.WriteLine("++btnAsyc {0} 结束", Thread.CurrentThread.ManagedThreadId);

        //}

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

        private void btnTask_Click(object sender, EventArgs e)
        {
            Console.WriteLine("开始==============");

            TaskFactory factory = new TaskFactory();
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 10; i++)
            {
                Task task = factory.StartNew(()=> {
                   Thread.Sleep(2000);
                   Console.WriteLine("+++++++++++线程Id={0} ,属于", Thread.CurrentThread.ManagedThreadId);
               });
                tasks.Add(task);
            }

            factory.ContinueWhenAll(tasks.ToArray(), tList =>
            {
                Console.WriteLine("TaskFactory.ContinueWhenAll结束===线程Id={0}", Thread.CurrentThread.ManagedThreadId);
            });
            
            factory.ContinueWhenAny(tasks.ToArray(), tList =>{
                Console.WriteLine("TaskFactory.ContinueWhenAny结束===线程Id={0}", Thread.CurrentThread.ManagedThreadId);
            });

            Task.WaitAny(tasks.ToArray());
            Console.WriteLine("Task.WaitAny结束==============");
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("Task.WaitAll全部结束==============");


            Console.WriteLine("结束==============");
        }

        private void method1(int i) {
            Console.WriteLine(i);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Console.WriteLine("开始==============");
            Task[] tasks = new Task[10];
            
            for (int i = 0; i < 10; i++)
            {
                int k = i;
                tasks[i] = new Task(() => {
                    Console.WriteLine("+++++++++++ask[] tasks1 = new Task[10];++++++++++ 参数{0}", k);
                });
            }
            Action<Task[]> action = x => {
                foreach (var item in x)
                {
                    item.Start();
                }
            };
            action.Invoke(tasks);
            Console.WriteLine("结束==============");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Console.WriteLine("开始==============");
            Console.WriteLine("住线程Id={0}", Thread.CurrentThread.ManagedThreadId);
            TaskFactory factory = new TaskFactory();
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 10; i++)
            {
                Action<object> action = x =>
                {
                    Thread.Sleep(2000);
                    Console.WriteLine("+++++++++++线程Id={0} ,属于", Thread.CurrentThread.ManagedThreadId);
                };
                Task task = factory.StartNew(action,i);
                tasks.Add(task);
            }

            factory.ContinueWhenAll(tasks.ToArray(), tList =>
            {
                Console.WriteLine("TaskFactory.ContinueWhenAll线程Id={0}", Thread.CurrentThread.ManagedThreadId);
                foreach (var item in tList)
                {
                    Console.WriteLine(item.AsyncState);
                }
            });

            factory.ContinueWhenAny(tasks.ToArray(), t => 
            {
                Console.WriteLine(t.AsyncState);
                Console.WriteLine("TaskFactory.ContinueWhenAny线程Id={0}", Thread.CurrentThread.ManagedThreadId);
            });
            
            Console.WriteLine("结束==============");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Console.WriteLine("开始==============");

            Parallel.Invoke(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Parallel1");
                Console.WriteLine("线程Id={0}", Thread.CurrentThread.ManagedThreadId);
            }, () =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Parallel2");
                Console.WriteLine("线程Id={0}", Thread.CurrentThread.ManagedThreadId);
            }, () =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Parallel3");
                Console.WriteLine("线程Id={0}", Thread.CurrentThread.ManagedThreadId);
            }, () =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Parallel4");
                Console.WriteLine("线程Id={0}", Thread.CurrentThread.ManagedThreadId);
            });

            Console.WriteLine("结束==============");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Console.WriteLine("开始==============");
            Console.WriteLine("住线程Id={0}", Thread.CurrentThread.ManagedThreadId);

            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.MaxDegreeOfParallelism = 3;
            Parallel.For(1, 5, parallelOptions, x => {
                Thread.Sleep(2000);
                Console.WriteLine(x);
                Console.WriteLine("For线程Id={0}", Thread.CurrentThread.ManagedThreadId);
            });

            List<User> users = new List<User>();
            users.Add(new User { Id = 1, Name = "a" });
            users.Add(new User { Id = 2, Name = "b" });
            users.Add(new User { Id = 3, Name = "c" });
            users.Add(new User { Id = 4, Name = "c" });
            users.Add(new User { Id = 5, Name = "c" });
            users.Add(new User { Id = 6, Name = "c" });
            users.Add(new User { Id = 7, Name = "c" });
            users.Add(new User { Id = 8, Name = "c" });
            users.Add(new User { Id = 9, Name = "c" });
            users.Add(new User { Id = 0, Name = "c" });
            users.Add(new User { Id = 11, Name = "c" });
            users.Add(new User { Id = 12, Name = "c" });
            users.Add(new User { Id = 13, Name = "c" });
            users.Add(new User { Id = 14, Name = "c" });
            users.Add(new User { Id = 15, Name = "c" });
            users.Add(new User { Id = 16, Name = "c" });
            users.Add(new User { Id = 17, Name = "c" });
            Parallel.ForEach(users, parallelOptions, x =>
            {
                Thread.Sleep(2000);
                Console.WriteLine(x);
                Console.WriteLine(x.Id);
                Console.WriteLine("ForEach线程Id={0}", Thread.CurrentThread.ManagedThreadId);
            });

           

            Console.WriteLine("结束==============");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Console.WriteLine("开始==============");
            //WatchTime

            TaskFactory factory = new TaskFactory();
            List<Task> tasks = new List<Task>();
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    Action<object> action = x => {
                        if (x.Equals(2))
                        {
                            Console.WriteLine("抛出异常 值{0}", x);
                            throw new Exception("抛出异常！");
                        }

                        Console.WriteLine("线程Id={0}", Thread.CurrentThread.ManagedThreadId);
                        Console.WriteLine("值{0}", x);
                    };
                    Task task = factory.StartNew(action, i);
                    tasks.Add(task);
                }
                Task.WaitAll(tasks.ToArray());
                Console.WriteLine("Task.WaitAll完成");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception出异常 {0}", ex.Message);
            }
            
            Console.WriteLine("结束==============");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Console.WriteLine("开始==============");
            //WatchTime

            TaskFactory factory = new TaskFactory();
            List<Task> tasks = new List<Task>();
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    Action<object> action = x => {
                        if (x.Equals(2))
                        {
                            Console.WriteLine("抛出异常 值{0}", x);
                            throw new Exception("抛出异常！");
                        }

                        Console.WriteLine("线程Id={0}", Thread.CurrentThread.ManagedThreadId);
                        Console.WriteLine("值{0}", x);
                    };
                    Task task = factory.StartNew(action, i);
                    tasks.Add(task);
                }
                Task.WaitAll(tasks.ToArray());
                Console.WriteLine("Task.WaitAll完成");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception出异常 {0}", ex.Message);
            }

            Console.WriteLine("结束==============");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Console.WriteLine("开始==============");
            Console.WriteLine("住线程Id={0}", Thread.CurrentThread.ManagedThreadId);

            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.MaxDegreeOfParallelism = 3;

            Parallel.For(1, 5, parallelOptions, x => {
                try
                {
                    Thread.Sleep(2000);
                    Console.WriteLine(x);
                    Console.WriteLine("For线程Id={0}", Thread.CurrentThread.ManagedThreadId);
                    if (x == 2)
                    {
                        throw new Exception("抛出异常！");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("For线程Id={0},抛出异常！", Thread.CurrentThread.ManagedThreadId);
                }
               
            });

            try
            {
                Parallel.ForEach(new int[] { 3, 4, 5, 6, 7, 8 }, parallelOptions, x =>
                {
                    Thread.Sleep(2000);
                    Console.WriteLine(x);
                    Console.WriteLine("ForEach线程Id={0}", Thread.CurrentThread.ManagedThreadId);
                    if (x == 4)
                    {
                        throw new Exception("抛出异常！");
                    }
                });
            }
            catch (Exception)
            {
                Console.WriteLine("ForEach线程Id={0},抛出异常！", Thread.CurrentThread.ManagedThreadId);
            }
            
            
            Console.WriteLine("结束==============");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Console.WriteLine("开始==============");

            TaskFactory factory = new TaskFactory();
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            List<Task> taskList = new List<Task>();
            for (int i = 0; i < 20; i++)
            {
                Action<object> action = x => {
                    try
                    {
                        Thread.Sleep(2000);
                        if (x.Equals(1))
                        {
                            throw new Exception("抛出异常！");
                        }
                        if (cancellationTokenSource.IsCancellationRequested)
                        {
                            Console.WriteLine("线程执行取消 值{0}", x);
                        }
                        else
                        {
                            Console.WriteLine("线程执行成功 值{0}", x);
                        }
                    }
                    catch (Exception ex)
                    {
                        cancellationTokenSource.Cancel();
                        Console.WriteLine("抛出异常 值{0}", x);
                    }
                };
                Task task = factory.StartNew(action, i, cancellationTokenSource.Token);
                taskList.Add(task);
            }
            Task.WaitAll(taskList.ToArray());

            Console.WriteLine("结束==============");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("a1", "11");
            d.Add("a2", "6");
            Console.WriteLine(d["a1"]);
            DealDatas(d, 3, "a1");
            Console.WriteLine(d["a1"]);
        }
        private static void DealDatas(Dictionary<string, string> configDic, int count, string code)
        {
            if (configDic == null)
                return ;
            if (configDic.ContainsKey(code))
            {
                configDic[code] = Convert.ToInt32(configDic[code]) > count ? count.ToString() : configDic[code];
            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Console.WriteLine("开始==============");
            for (int i = 0; i < 10; i++)
            {
                int k = i;
                Thread.Sleep(1000);
                Action action = () => {
                    Console.WriteLine(k);
                };

                action.BeginInvoke(null, null);
            }
            Console.WriteLine("结束==============");
        }
        private object lockOb = new object();
        private void button15_Click(object sender, EventArgs e)
        {
            Console.WriteLine("开始==============");

            TaskFactory taskFactory = new TaskFactory();
            List<Task> tasks = new List<Task>();
            int cpunt = 0;
            for (int i = 0; i < 10000; i++)
            {
                int k = i;
                tasks.Add(taskFactory.StartNew(()=> {
                    lock (lockOb)
                    {
                        cpunt += k;
                    }
                }));
            }
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine(cpunt);
            Console.WriteLine("结束==============");
        }

        private async Task<int> NoReturn()
        {
            Console.WriteLine("开始async==============");
            TaskFactory taskFactory = new TaskFactory();

            return await Task.Run(() =>
            {
                Console.WriteLine("执行async");
                return 1;
            });
          
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Console.WriteLine("开始==============");
            var result = NoReturn();
            Console.WriteLine("结束{0}", result.Result);
            Console.WriteLine("结束==============");

            Task<long> task = new Task<long>(() => {
                return 1L;
            });
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++btn_Async_Click {0} 开始", Thread.CurrentThread.ManagedThreadId);

            IAsyncResult asyncResult = null;

            doSomeMethodDelegate methodDelegate = new doSomeMethodDelegate(DoSomeThing);
            AsyncCallback asyncCallback = x => {
                Console.WriteLine("AsyncState="+x.AsyncState);
                Console.WriteLine("asyncCallback");
                Console.WriteLine("asyncResult==asyncCallback?"+x.Equals(asyncResult));

            };

            asyncResult = methodDelegate.BeginInvoke("复习", asyncCallback, "@object");

            int i = 0;
            while (!asyncResult.IsCompleted)
            {
                Console.WriteLine("+++++++++++正在计算中！++++++++++ + 已经完成 {0}", 10 * i++);
                Thread.Sleep(100);
            }


            Console.WriteLine("++++++++++++++++++++++++++++++++++++++btn_Async_Click {0} 结束", Thread.CurrentThread.ManagedThreadId);
        }

        private async void button18_Click(object sender, EventArgs e)
        {
            var t = GetData();
            button18.Text= "OK";
            var txt = await t;
            label2.Text= txt;
        }

        public async Task<string> GetData()
        {
            var txt = string.Empty;
            using (HttpClient client=new HttpClient())
            {
              var res =  await client.GetStringAsync("https://blog.stephencleary.com/2012/02/async-and-await.html");
                txt = res;
            }
            return txt;
        }
    }
}


   
