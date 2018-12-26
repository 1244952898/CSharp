using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo.访问自定义特性
{
    [Example(StringValue = "This is a string.")]
    class Class1
    {
        public static void Main1()
        {
            System.Reflection.MemberInfo info = typeof(Class1);
            foreach (var attrib in info.GetCustomAttributes(true))
            {
                Console.WriteLine(attrib);
            }

            Type t= typeof(Class1);
            foreach (var attrib in t.GetCustomAttributes(true))
            {
                Console.WriteLine(attrib);
            }
        }
    }
}
