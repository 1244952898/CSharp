using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateAndEvent.Version6
{
    public class MyPulisher6
    {
        public delegate void MethodDelegateHandler(int i);
        // 声明一个私有事件
        public event MethodDelegateHandler MethodEvent;

        public int Count { get; set; }

        public void DoSomethings()
        {
            Console.WriteLine($"DoSomethings {Count++}");
            var delegates = MethodEvent.GetInvocationList();
            foreach (var dl in delegates)
            {
                try
                {
                    #region 版本1
                    var d = (MethodDelegateHandler)dl;
                    d(Count);
                    #endregion

                    #region 版本2
                    dl.DynamicInvoke(Count+101111);
                    #endregion

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
               
            }
        }

    }
}
