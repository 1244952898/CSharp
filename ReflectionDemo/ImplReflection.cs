using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo
{
    public class ImplReflection
    {
        public static void GMain(Type type)
        {
            //Type type = typeof(Dictionary<,>);
            Console.WriteLine("   Is this a generic type? {0}",type.IsGenericType);
            Console.WriteLine("   Is this a generic type? {0}",type.IsGenericTypeDefinition);
            if (type.IsGenericTypeDefinition)
            {
                Type genericTypeDefinitionType = type.MakeGenericType(typeof(string), typeof(string));
                Console.WriteLine();
                DealGenericTypeReflection(genericTypeDefinitionType);
            }
            if (type.IsGenericType)
            {
                DealGenericTypeReflection(type);
            }
        }

        public static void DealGenericTypeReflection(Type type)
        {
            Type[] types = type.GetGenericArguments();
        }

    }
}
