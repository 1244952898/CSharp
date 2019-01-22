using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ReflectionDemo.ClassesGeneric;
using ReflectionDemo.动态加载和使用类型;
using ReflectionDemo.构造泛型类型的实例;
using ReflectionDemo.访问自定义特性;
using RelflectionDemo_将程序集加载到仅反射上下文中;

namespace ReflectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(Test);
            //ListMembers.GetMain(type);

            //Mymemberinfo.GMain();

            Mymemberinfo.MainAll();

            //GenericRelection.GMain();

            //GenericParameterDemo.GMain();

            // Dictionary <string,string> dictionary=new Dictionary<string, string>();

            //   ImplReflection.GMain(dictionary.GetType());

            //#region 构造泛型类型的实例

            //// Two ways to get a Type object that represents the generic
            //// type definition of the Dictionary class. 
            ////
            //// Use the typeof operator to create the generic type 
            //// definition directly. To specify the generic type definition,
            //// omit the type arguments but retain the comma that separates
            //// them.
            //Type d1 = typeof(Dictionary<,>);

            //// You can also obtain the generic type definition from a
            //// constructed class. In this case, the constructed class
            //// is a dictionary of Example objects, with String keys.
            //Dictionary<string, Example> d2 = new Dictionary<string, Example>();
            //// Get a Type object that represents the constructed type,
            //// and from that get the generic type definition. The 
            //// variables d1 and d4 contain the same type.
            //Type d3 = d2.GetType();
            //Type d4 = d3.GetGenericTypeDefinition();

            //// Display information for the generic type definition, and
            //// for the constructed type Dictionary<String, Example>.
            //Example.DisplayGenericType(d1);
            //Example.DisplayGenericType(d2.GetType());
            //Type[] typeArgs = { typeof(string), typeof(Example) };
            //Type constructed = d1.MakeGenericType(typeArgs);

            //Example.DisplayGenericType(constructed);

            //object o = Activator.CreateInstance(constructed);
            //Console.WriteLine("\r\nCompare types obtained by different methods:");
            //Console.WriteLine("   Are the constructed types equal? {0}",
            //    (d2.GetType() == constructed));
            //Console.WriteLine("   Are the generic definitions equal? {0}",
            //    (d1 == constructed.GetGenericTypeDefinition()));

            //Example.DisplayGenericType(typeof(Test<>));
            //#endregion

            #region 动态加载和使用类型

            // Type myType = typeof(MySimpleClass);
            // MySimpleClass myInstance = new MySimpleClass();
            // MyCustomBinder binder = new MyCustomBinder();

            // MethodInfo methodInfo = myType.GetMethod("MyMethod", BindingFlags.Public|BindingFlags.Instance, binder, new Type[]{typeof(string),typeof(int)},null);

            // Console.WriteLine(methodInfo.ToString());

            // myType.InvokeMember("MyMethod", BindingFlags.InvokeMethod, binder, myInstance,new Object[] {"Testing...", (int) 32});
            //// myType.InvokeMember("MyMethod", BindingFlags.InvokeMethod,null,myInstance, new Object[] { "Testing...", (int)32 });

            // Type t = typeof(CustomBinderDriver);
            // BindingFlags flags = BindingFlags.InvokeMethod | BindingFlags.Instance |
            //                      BindingFlags.Public | BindingFlags.Static;
            // object[] argss;
            // // Case 1. Neither argument coercion nor member selection is needed.
            // argss = new object[] { };
            // t.InvokeMember("PrintBob", flags, binder, null, argss);

            // // Case 2. Only member selection is needed.
            // argss = new object[] { 42 };
            // t.InvokeMember("PrintValue", flags, binder, null, argss);

            // // Case 3. Only argument coercion is needed.
            // argss = new object[] { "5.5" };
            // t.InvokeMember("PrintNumber", flags, binder, null, argss);
            #endregion

            #region 动态加载和使用类型

            //Test1.Main();
            #endregion

            #region 访问自定义特性

            //Class1.Main1();

            #endregion

            #region 使用反射将委托挂钩

            //Assembly assem = typeof(Example).Assembly;
            //Type texType = assem.GetType("ExampleForm");
            //Object exFormAsObj = Activator.CreateInstance(texType);
            //EventInfo evClick = texType.GetEvent("Click");
            //Type tDelegate = evClick.EventHandlerType;

            //MethodInfo methodInfo = typeof(Example).GetMethod("LuckyHandler", BindingFlags.NonPublic | BindingFlags.Instance);

            //Delegate d = Delegate.CreateDelegate(tDelegate, texType, methodInfo);

            //MethodInfo addHandler = evClick.GetAddMethod();
            //Object[] addHandlerArgs = { d };
            //addHandler.Invoke(exFormAsObj, addHandlerArgs);

            #endregion

            Console.ReadKey();
        }
    }
}
