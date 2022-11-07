using System;
using System.Collections.Generic;
using System.Text;

namespace MyIOC_Common_Version2.Attriutes
{
    /// <summary>
    /// 构造函数注入特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Constructor)]
    public class ConstructorInjectionAttribute:Attribute
    {
    }
}
