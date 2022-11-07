using System;
using System.Collections.Generic;
using System.Text;

namespace MyIOC_Common_Version2.Attriutes
{
    /// <summary>
    /// 简称（别名）
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter|AttributeTargets.Property)]
    public class ParameterShortNameAttribute:Attribute
    {
        public string ShortName { get; private set; }

        public ParameterShortNameAttribute(string shortName)
        {
            this.ShortName = shortName;
        }
    }
}
