using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReflectionDemo.ClassesGeneric;
using ReflectionDemo.构造泛型类型的实例;

namespace ReflectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Type type = typeof(Test);
            //ListMembers.GetMain(type);

            //Mymemberinfo.GMain();

            //Mymemberinfo.MainAll();

            //GenericRelection.GMain();

            //GenericParameterDemo.GMain();

            // Dictionary <string,string> dictionary=new Dictionary<string, string>();

            //   ImplReflection.GMain(dictionary.GetType());

            #region 构造泛型类型的实例

            // Two ways to get a Type object that represents the generic
            // type definition of the Dictionary class. 
            //
            // Use the typeof operator to create the generic type 
            // definition directly. To specify the generic type definition,
            // omit the type arguments but retain the comma that separates
            // them.
            Type d1 = typeof(Dictionary<,>);

            // You can also obtain the generic type definition from a
            // constructed class. In this case, the constructed class
            // is a dictionary of Example objects, with String keys.
            Dictionary<string, Example> d2 = new Dictionary<string, Example>();
            // Get a Type object that represents the constructed type,
            // and from that get the generic type definition. The 
            // variables d1 and d4 contain the same type.
            Type d3 = d2.GetType();
            Type d4 = d3.GetGenericTypeDefinition();

            // Display information for the generic type definition, and
            // for the constructed type Dictionary<String, Example>.
            Example.DisplayGenericType(d1);
            Example.DisplayGenericType(d2.GetType());
            Type[] typeArgs = { typeof(string), typeof(Example)};
            Type constructed = d1.MakeGenericType(typeArgs);

            Example.DisplayGenericType(constructed);

            object o = Activator.CreateInstance(constructed);
            Console.WriteLine("\r\nCompare types obtained by different methods:");
            Console.WriteLine("   Are the constructed types equal? {0}",
                (d2.GetType() == constructed));
            Console.WriteLine("   Are the generic definitions equal? {0}",
                (d1 == constructed.GetGenericTypeDefinition()));

            Example.DisplayGenericType(typeof(Test<>));
            #endregion
            Console.ReadKey();
        }
    }
}
