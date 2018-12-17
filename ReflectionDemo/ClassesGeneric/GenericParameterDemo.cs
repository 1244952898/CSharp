using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo.ClassesGeneric
{
   public class B<T, U> { }
   public class D<V, W> : B<int, V> { }

    public class GenericParameterDemo
    {
        public static void GMain()
        {
            Type dType = typeof(D<,>);
            Type bType= dType.BaseType;
            Console.WriteLine(" dType.IsGenericType=" + bType.IsGenericType);
            Console.WriteLine(" dType.IsGenericTypeDefinition=" + bType.IsGenericTypeDefinition);
            Type[] dTypeArguments = bType.GetGenericArguments();
            foreach (var type in dTypeArguments)
            {
                Console.WriteLine(type.FullName + "===type.IsGenericParameter=>" + type.IsGenericParameter);
            }
        }
    }
}
