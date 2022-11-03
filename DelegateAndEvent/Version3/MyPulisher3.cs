using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateAndEvent.Version3
{
    /// <summary>
    /// 定义委托
    /// </summary>
    /// <param name="num"></param>
    public delegate void NumberChangedEventHandler(int num);

    /// <summary>
    /// 定义事件发布者
    /// </summary>
    internal class MyPublishser3
    {
        public int count { get; set; }

        public event NumberChangedEventHandler numberChangedEventHandler;

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
