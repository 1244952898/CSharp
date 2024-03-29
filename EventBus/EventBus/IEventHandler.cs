﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EventBus.EventBus
{
    /// <summary>
    /// 定义事件处理器公共接口，所有的事件处理都要实现该接口
    /// </summary>
    public interface IEventHandler
    {

    }

    /// <summary>
    /// 泛型事件处理器接口
    /// </summary>
    /// <typeparam name="TEventData"></typeparam>
    public interface IEventHandler<TEventData> : IEventHandler where TEventData : IEventData
    {
    }
}
