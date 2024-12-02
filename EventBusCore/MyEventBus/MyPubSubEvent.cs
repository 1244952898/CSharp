using System;
using System.Collections.Generic;

namespace EventBusCore.MyEventBus
{
    /// <summary>
    /// 泛型事件
    /// </summary>
    public class MyPubSubEvent<T> : MyEventBase where T : EventArgs
    {
        protected static readonly object Locker = new object();

        protected readonly List<Action<object, T>> Subscriptions = new List<Action<object, T>>();

        /// <summary>
        ///  注册
        /// </summary>
        /// <param name="eventHandler"></param>
        public void Subscribe(Action<object, T> eventHandler)
        {
            lock (Locker)
            {
                if (!Subscriptions.Contains(eventHandler))
                {
                    Subscriptions.Add(eventHandler);
                }
            }
        }

        /// <summary>
        /// 移除注册
        /// </summary>
        /// <param name="eventHandler"></param>
        public void UnSubscribe(Action<object, T> eventHandler)
        {
            lock (Locker)
            {
                if (Subscriptions.Contains(eventHandler))
                {
                    Subscriptions.Remove(eventHandler);
                }
            }
        }

        public virtual void Publish(object sender, T eventArgs)
        {
            lock (Locker)
            {
                foreach (var action in Subscriptions)
                {
                    action(sender, eventArgs);
                }
            }
        }
    }
}
