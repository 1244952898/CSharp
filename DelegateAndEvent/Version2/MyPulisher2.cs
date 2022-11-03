using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateAndEvent.Version2
{
    /// <summary>
    /// 定义委托
    /// </summary>
    /// <param name="num"></param>
    public delegate void NumberChangedEventHandler(int num);

    /// <summary>
    /// 定义事件发布者
    /// </summary>
    internal class MyPublishser2
    {
        public int count { get; set; }

        public NumberChangedEventHandler numberChangedEventHandler;

        public void DoSomething()
        {
            Console.WriteLine("Do Something!");
            if (numberChangedEventHandler!=null)
            {
                count++;
                numberChangedEventHandler(count);
            }
        }
    }
}
