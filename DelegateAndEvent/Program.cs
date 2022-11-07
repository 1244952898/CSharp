using DelegateAndEvent.Version2;
using DelegateAndEvent.Version3;
using DelegateAndEvent.Version4;
using DelegateAndEvent.Version5;
using DelegateAndEvent.Version6;
using DelegateAndEvent.Version7;
using DelegateAndEvent.Version8;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DelegateAndEvent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task<int> resultTask = Task.Run(() =>
            //{
            //    return 1;
            //});

            //Func<string,int,string> fc = (str,i) =>
            //{
            //    return "";
            //};

            AwaitAsyncDemo asyncDemo=new AwaitAsyncDemo();
            asyncDemo.Show();
            bool isb = true;
            if (isb)
            {
                return;
            }


            #region 委托事件

            #region Version2

            {

                MyPublishser2 myPublishser2 = new MyPublishser2();
                MySubscriber2 mySubscriber2 = new MySubscriber2();
                myPublishser2.numberChangedEventHandler = mySubscriber2.GetNum;

                /*
                 事件的本意应该为在事件发布者在其本身的某个行为中触发，比如说在方法DoSomething()中满足某个条件后触发。
                 通过添加event关键字来发布事件，事件发布者的封装性会更好，事件仅仅是供其他类型订阅，而客户端不能直接触发事件（语句pub.NumberChanged(100)无法通过编译）
                 */
                myPublishser2.numberChangedEventHandler(100);
            }

            #endregion

            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

            #region Version3

            {
                MyPublishser3 myPublishser3 = new MyPublishser3();
                MySubscriber3 mySubscriber3 = new MySubscriber3();
                myPublishser3.numberChangedEventHandler += mySubscriber3.GetNum;

                //事件只能在事件发布者Publisher类的内部触发（比如在方法pub.DoSomething()中），换言之，就是NumberChanged(100)语句只能在Publisher内部被调用。
                //myPublishser3.numberChangedEventHandler(100);
                myPublishser3.DoSomething();
            }

            #endregion

            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

            #region Version4

            {
                MyPulisher4 myPublishser4 = new MyPulisher4();
                MySubscriber4 mySubscriber4 = new MySubscriber4();
                MySubscriber4 mySubscriber44 = new MySubscriber4();
                MySubscriber4 mySubscriber444 = new MySubscriber4();

                myPublishser4.MethodEvent += mySubscriber4.OnEvent;
                myPublishser4.MethodEvent += mySubscriber44.OnEvent;
                myPublishser4.MethodEvent += mySubscriber444.OnEvent;
                var lst = myPublishser4.DoSomethings();
                Console.WriteLine(string.Join(' ', lst));
            }

            #endregion

            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

            #region Version5 让事件只允许一个客户订阅

            {
                var myPublishser5 = new MyPulisher5();
                var mySubscriber5 = new MySubscriber5();
                var mySubscriber55 = new MySubscriber5();
                myPublishser5.Register(mySubscriber5.OnEvent);
                myPublishser5.Register(mySubscriber55.OnEvent);

                myPublishser5.DoSomethings();
            }

            #endregion

            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

            #region Version6 抛出异常

            {
                /*
                if (MyEvent != null) 
                {
                    try {
                        MyEvent(this, EventArgs.Empty);
                    } catch (Exception e) {
                        Console.WriteLine("Exception: {0}", e.Message);
                    }
                }
                 尽管我们捕获了异常，使得程序没有异常结束，但是却影响到了后面的订阅者，因为Subscriber3也订阅了事件，但是却没有收到事件通知（它的方法没有被调用）。
                */
                var myPublishser6 = new MyPulisher6();
                var mySubscriber6 = new MySubscriber6();
                var mySubscriber66 = new MySubscriber66();
                var mySubscriber666 = new MySubscriber666();

                myPublishser6.MethodEvent += mySubscriber6.OnEvent;
                myPublishser6.MethodEvent += mySubscriber66.OnEvent;
                myPublishser6.MethodEvent += mySubscriber666.OnEvent;

                myPublishser6.DoSomethings();
            }

            #endregion

            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

            #region Version7 委托中订阅者方法超时的处理

            var myPublishser7 = new MyPulisher7();
            var mySubscriber7 = new MySubscriber7();
            var mySubscriber77 = new MySubscriber77();
            var mySubscriber777 = new MySubscriber777();

            myPublishser7.DelegateEvent += mySubscriber7.OnEvent;
            myPublishser7.DelegateEvent += mySubscriber77.OnEvent;
            myPublishser7.DelegateEvent += mySubscriber777.OnEvent;

            var results = myPublishser7.DoSomethings();
            foreach (var item in results)
            {
                Console.WriteLine(item);
            }

            #endregion

            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

            #region Version8

            {
                //在事件的发布和订阅这一过程中使用了异步调用，而在事件发布者和订阅者之间往往是松耦合的，发布者通常不需要获得订阅者方法执行的情况；而当使用异步调用时，更多情况下是为了提升系统的性能，而并非专用于事件的发布和订阅这一编程模型

                Console.WriteLine("Client application started!\n");
                Thread.CurrentThread.Name = "Main Thread";

                var cal = new Calculator0();
                AddDelegate addDelegate = cal.Add;

                var asyncResult = addDelegate.BeginInvoke(3, 5, null, null);
                //var asyncResult= addDelegate.BeginInvoke(3, 5, ar =>
                //{
                //    var data = ar.AsyncState;
                //    Console.WriteLine("{0}: Result, {1}; Data: {2}\n", Thread.CurrentThread.Name, "rtn", data);
                //}, "Not get Data");

                // 做某些其它的事情，模拟需要执行3秒钟
                for (int i = 1; i <= 3; i++)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(i));
                    Console.WriteLine("{0}: Client executed {1} second(s).",
                        Thread.CurrentThread.Name, i);
                }

                asyncResult.AsyncWaitHandle.WaitOne();
                OnAddComplete(addDelegate, asyncResult);
            }

            #endregion

            #endregion

             #region 多线程

            #region Thread

            {
                //先操作系统管理线程，响应不灵敏，不好控制
                Thread t = new Thread(new ThreadStart(() => { }));
                //t.Start();
                //t.Resume();
                //t.Suspend();
                //t.Join();
                //t.Abort();
            }

            #endregion

            #region ThreadPool

            {
                //无法控制返回，线程状态
                ThreadPool.QueueUserWorkItem(state => { Console.WriteLine(state); }, "参数");
            }

            #endregion

            #region Parallel

            {
                //启动多线程，主线程也在运行之中，
                //可以控制并发数量
                ParallelOptions parallelOptions = new ParallelOptions
                {
                    MaxDegreeOfParallelism = 2
                };
                Console.WriteLine($"This is Main—— {Thread.CurrentThread.ManagedThreadId} Start");
                Parallel.Invoke(parallelOptions, () =>
                    {
                        Console.WriteLine($"This is parallel——1 {Thread.CurrentThread.ManagedThreadId} Start");
                        Thread.Sleep(4000);
                        Console.WriteLine($"This is parallel——1 {Thread.CurrentThread.ManagedThreadId} Start");
                    },
                    () =>
                    {
                        Console.WriteLine($"This is parallel——2 {Thread.CurrentThread.ManagedThreadId} Start");
                        Thread.Sleep(4000);
                        Console.WriteLine($"This is parallel——2 {Thread.CurrentThread.ManagedThreadId} Start");
                    },
                    () =>
                    {
                        Console.WriteLine($"This is parallel——3 {Thread.CurrentThread.ManagedThreadId} Start");
                        Thread.Sleep(4000);
                        Console.WriteLine($"This is parallel——3 {Thread.CurrentThread.ManagedThreadId} Start");
                    }
                );
            }

            #endregion

            #region Task

            {
                Action action = () =>
                {
                    Console.WriteLine($"This is Task——1 {Thread.CurrentThread.ManagedThreadId} Start");
                    Thread.Sleep(4000);
                    Console.WriteLine($"This is Task——1 {Thread.CurrentThread.ManagedThreadId} Start");
                };
                Task task = new Task(action);
                task.Start();

                var taskList = new List<Task>
                {
                    Task.Run(() =>
                    {
                        Console.WriteLine($"This is Task Run——1 {Thread.CurrentThread.ManagedThreadId} Start");
                        Thread.Sleep(4000);
                        Console.WriteLine($"This is Task Run——1 {Thread.CurrentThread.ManagedThreadId} Start");
                    }),
                    Task.Run(() =>
                    {
                        Console.WriteLine($"This is Task Run——2 {Thread.CurrentThread.ManagedThreadId} Start");
                        Thread.Sleep(4000);
                        Console.WriteLine($"This is Task Run——2 {Thread.CurrentThread.ManagedThreadId} Start");
                    })
                };

                //尽量不要线程套线程
                Task.WaitAny(taskList.ToArray());
                Task.WaitAll(taskList.ToArray());

                //Task.WhenAll(taskList);

                //Continue后续的线程可能是新线程，可能是刚完成任务的线程，不可能是主线程

                TaskFactory taskFactory = new TaskFactory();
                taskFactory.ContinueWhenAny(taskList.ToArray(), x => { Console.WriteLine("ContinueWhenAny"); });
                taskFactory.ContinueWhenAll(taskList.ToArray(), x => { Console.WriteLine("ContinueWhenAny"); });

                //多线程不可预测的

                //List数组结构，内存上连续摆放，多线程同时执行某一时刻，去增加数据，同一时刻操作同一个内存位置，2个CPU同时发出命令，内容先执行一个，再执行一个，就出现覆盖
                var inList = new List<int>();
                for (var i = 0; i < 10000; i++)
                {
                    Task.Run(() => { inList.Add(i); });
                }

                Console.WriteLine($"{inList.Count}");
            }

            #endregion

            #endregion
        }

        public static object[] InvokeEvent(Delegate onEvent, params object[] parameters)
        {
            var result = new List<object>();
            var delegates = onEvent.GetInvocationList();
            foreach (var dl in delegates)
            {
               var res =  dl.DynamicInvoke(parameters);
                result.Add(res);
            }

            return result.ToArray();
        }

        static void OnAddComplete(AddDelegate del, IAsyncResult asyncResult)
        {
            /*
                AsyncResult result = (AsyncResult)asyncResult;
                AddDelegate del = (AddDelegate)result.AsyncDelegate;
                string data = (string)asyncResult.AsyncState;

                int rtn = del.EndInvoke(asyncResult);
                Console.WriteLine("{0}: Result, {1}; Data: {2}\n",Thread.CurrentThread.Name, rtn, data);
             */
            int rtn = del.EndInvoke(asyncResult);
            Console.WriteLine("{0}: Result, {1}; Data: {2}\n",
                Thread.CurrentThread.Name, rtn,"");
        }

    }
}
