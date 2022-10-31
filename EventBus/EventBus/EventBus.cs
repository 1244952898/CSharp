using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EventBus.EventBus
{
    public class EventBus
    {
        public static EventBus Default => new EventBus();

        /// <summary>
        /// 定义线程安全集合
        /// </summary>
        private readonly ConcurrentDictionary<Type, List<Type>> _eventAndHandlerMapping;

        public EventBus()
        {
            _eventAndHandlerMapping = new ConcurrentDictionary<Type, List<Type>>();
            MapEventToHandler();
        }

        /// <summary>
        ///通过反射，将事件源与事件处理绑定
        /// </summary>
        private void MapEventToHandler()
        {
            Assembly[] assemblies = AgileHelper.TypeFinder.GetAssemblies().ToArray();
        }
    }
}
