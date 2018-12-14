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
            GenericDemo<int> genericDemo=new GenericDemo<int>();
            Type typeDemo = genericDemo.GetType();
            Console.WriteLine("type.IsGenericType=" + type.IsGenericType);
            Console.WriteLine("type.ContainsGenericParameters=" + type.ContainsGenericParameters);
            Console.WriteLine("typeDemo.ContainsGenericParameters=" + typeDemo.ContainsGenericParameters);
            MethodInfo[] methodInfos = type.GetMethods();
            Console.WriteLine("methodInfos.Length=" + methodInfos.Length);
            Print(methodInfos);
            Type[] t1= type.GetGenericArguments();
            Type t = type.GetGenericTypeDefinition();

           Type newTye = type.MakeGenericType(typeof(string));
            Console.WriteLine("newTye.ContainsGenericParameters=" + newTye.ContainsGenericParameters);
        }

        public static void Print(MemberInfo[] infos)
        {
            foreach (var memberInfo in infos)
            {
                if (memberInfo is MethodInfo info)
                {
                    Console.WriteLine(memberInfo.Name+" =>IsGenericMethod=" + info.IsGenericMethod+ "========info.IsGenericMethodDefinition=" + info.IsGenericMethodDefinition);
                    if (info.IsGenericMethodDefinition)
                    {
                        MethodInfo methodInfo = info.MakeGenericMethod(typeof(int));
                        Console.WriteLine("========methodInfo.IsGenericMethodDefinition=" + methodInfo.IsGenericMethodDefinition);
                    }
                }
            }
        }
    }
}
