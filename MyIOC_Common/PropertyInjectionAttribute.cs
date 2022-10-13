using System;
using System.Collections.Generic;
using System.Text;

namespace MyIOC_Common
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyInjectionAttribute: Attribute
    {
    }
}
