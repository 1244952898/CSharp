using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo.动态加载和使用类型
{
    public class CustomBinderDriver
    {
        public static void PrintBob()
        {
            Console.WriteLine("PrintBob");
        }

        public static void PrintValue(long value)
        {
            Console.WriteLine("PrintValue({0})", value);
        }

        public static void PrintValue(string value)
        {
            Console.WriteLine("PrintValue\"{0}\")", value);
        }

        public static void PrintNumber(double value)
        {
            Console.WriteLine("PrintNumber ({0})", value);
        }
    }
}
