using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo.ClassesGeneric
{
    public class GenericRelection
    {
        public static void GMain()
        {
            Type type = typeof(GenericDemo<>);
            Console.WriteLine("IsGenericType="+ type.IsGenericType);
            MethodInfo[] methodInfos = type.GetMethods();
            Console.WriteLine("methodInfos.Length=" + methodInfos.Length);
            Print(methodInfos);

        }

        public static void Print(MemberInfo[] infos)
        {
            foreach (var memberInfo in infos)
            {
                if (memberInfo is MethodInfo info)
                {
                    Console.WriteLine(memberInfo.Name+" =>IsGenericMethod=" + info.IsGenericMethod);
                }
            }
        }
    }
}
