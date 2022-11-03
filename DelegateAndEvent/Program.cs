using DelegateAndEvent.Version2;
using DelegateAndEvent.Version3;
using DelegateAndEvent.Version4;
using DelegateAndEvent.Version5;
using DelegateAndEvent.Version6;
using DelegateAndEvent.Version7;
using System;
using System.Collections.Generic;

namespace DelegateAndEvent
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
                var myPublishser5= new MyPulisher5();
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

            var results= myPublishser7.DoSomethings();
            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
           
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
    }
}
