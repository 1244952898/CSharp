using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace EventBusCore.MyEventBus
{
    /// <summary>
    /// 事件总线
    /// </summary>
    public class MyEventBus
    {
        private static MyEventBus _default;

        private static readonly object locker = new object();

        private Dictionary<Type, MyEventBase> eventDic = new Dictionary<Type, MyEventBase>();
        //ConcurrentDictionary

        /// <summary>
        /// 默认事件总线实例，建议只使用此实例
        /// </summary>
        public static MyEventBus Default
        {
            get
            {
                if (_default != null) 
                    return _default;

                lock (locker)
                {
                    _default ??= new MyEventBus();
                }
                return _default;
            }
            set
            {
                _default = value;
            }
        }

        /// <summary>
        /// 构造函数，自动加载EventBase的派生类实现
        /// </summary>
        public MyEventBus()
        {
            Type type = typeof(MyEventBase);
            Type typePubSub = typeof(MyPubSubEvent<>);
            Assembly assembly = Assembly.GetAssembly(type);
            List<Type> typeList = assembly.GetTypes().Where(t => t != type && t != typePubSub && type.IsAssignableFrom(t)).ToList();
            foreach (var ty in typeList)
            {
                MyEventBase myEventBase = (MyEventBase)assembly.CreateInstance(ty.FullName);
                eventDic.Add(ty,myEventBase);
            }
        }

        /// <summary>
        /// 获取事件实例
        /// </summary>
        /// <typeparam name="TEvent">事件类型</typeparam>
        /// <returns></returns>
        public TEvent GetEvent<TEvent>() where TEvent:MyEventBase
        {
            return (TEvent)eventDic[typeof(TEvent)];
        }


        /// <summary>
        /// 添加事件类型
        /// </summary>
        /// <typeparam name="TEvent"></typeparam>
        public void AddEvent<TEvent>() where TEvent : MyEventBase, new()
        {
            lock (locker)
            {
                Type type = typeof(TEvent);
                if (!eventDic.ContainsKey(type))
                {
                    eventDic.Add(type, new TEvent());
                }
            }
        }

        public void RemoveEvent<TEvent>() where TEvent: MyEventBase,new()
        {
            lock (locker)
            {
                Type type = typeof(TEvent);
                if (eventDic.ContainsKey(type))
                {
                    eventDic.Remove(type);
                }
            }
        }

    }
}
