using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateAndEvent.Version5
{
  

    /// <summary>
    /// 
    /// </summary>
    public class MyPulisher5
    {
        public delegate void MethodDelegateHandler(int i);
        // 声明一个私有事件
        private event MethodDelegateHandler MethodEvent;

        public int Count { get; set; }

        public void DoSomethings()
        {
            Console.WriteLine($"DoSomethings {Count++}");
            var delegates = MethodEvent.GetInvocationList();
            foreach (var dl in delegates)
            {
                var d = (MethodDelegateHandler)dl;
                d(Count);
            }
        }

        /// <summary>
        /// 注册事件
        /// </summary>
        /// <param name="me"></param>
        public void Register(MethodDelegateHandler me)
        {
            MethodEvent = me;
        }

        /// <summary>
        /// 取消注册
        /// </summary>
        /// <param name="me"></param>
        public void UnRegister(MethodDelegateHandler me)
        {
            MethodEvent -= me;
        }
    }
}
