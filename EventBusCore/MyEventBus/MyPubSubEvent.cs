using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBusCore.MyEventBus
{
    /// <summary>
    /// 泛型事件
    /// </summary>
    public class MyPubSubEvent<T>:MyEventBase where T: EventArgs
    {
        protected static readonly object locker = new object();

        protected readonly List<Action<object, T>> subscriptions = new List<Action<object, T>>();

        /// <summary>
        ///  注册
        /// </summary>
        /// <param name="eventHandler"></param>
        public void Subscribe(Action<object,T> eventHandler)
        {
            lock (locker)
            {
                if (!subscriptions.Contains(eventHandler))
                {
                    subscriptions.Add(eventHandler);
                }
            }
        }

        /// <summary>
        /// 移除注册
        /// </summary>
        /// <param name="eventHandler"></param>
        public void unSubscribe(Action<object, T> eventHandler)
        {
            lock (locker)
            {
                if (subscriptions.Contains(eventHandler))
                {
                    subscriptions.Remove(eventHandler);
                }
            }
        }

        public virtual void Publish(object sender,T eventArgs)
        {
            lock (locker)
            {
                for (int i = 0; i < subscriptions.Count; i++)
                {
                    subscriptions[i](sender, eventArgs);
                }
            }
        }
    }
}
