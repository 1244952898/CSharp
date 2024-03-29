﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBusCore.MyEventBus
{
    /// <summary>
    /// 泛型事件实现-TestAEvent，重写事件的触发逻辑
    /// </summary>
    public class TestAEvent : MyPubSubEvent<TestAEventArgs>
    {
        public override void Publish(object sender, TestAEventArgs eventArgs)
        {
            lock (Locker)
            {
                foreach (var action in Subscriptions)
                {
                    var action1 = action;
                    Task.Run(() => action1(sender, eventArgs));
                }
            }
        }
    }

    /// <summary>
    /// 泛型事件参数实现-TestAEventArgs
    /// </summary>
    public class TestAEventArgs : MyPubSubEventArgs<string> 
    { 
    
    }

    /// <summary>
    /// 泛型事件实现-TestBEvent
    /// </summary>
    public class TestBEvent : MyPubSubEvent<TestBEventArgs> 
    { 

    }

    /// <summary>
    /// 泛型事件参数实现-TestBEventArgs
    /// </summary>
    public class TestBEventArgs : MyPubSubEventArgs<int> 
    {
        
    }
}
