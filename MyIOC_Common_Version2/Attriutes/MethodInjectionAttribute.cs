using System;
using System.Collections.Generic;
using System.Text;

namespace MyIOC_Common_Version2.Attriutes
{
    /// <summary>
    /// 方法注入特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class MethodInjectionAttribute:Attribute
    {
    }
}
