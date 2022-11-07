using System;
using System.Collections.Generic;
using System.Text;

namespace MyIOC_Common_Version2
{
    /// <summary>
    /// 生命周期
    /// </summary>
    public enum LifetimeTypeEnum
    {
        Transient, //瞬时
        Singleton,
        Scope, //作用域
        PerThread //线程单例
    }
}
