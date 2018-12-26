using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

namespace RelflectionDemo_将程序集加载到仅反射上下文中
{
    [Example(ExampleKind.SecondKind,new string[] { "String array argument, line 1","String array argument, line 2","String array argument, line 3"}, Note = "This is a note on the class.", Numbers = new [] { 53, 57, 59 })]
    public class Test1
    {
        [Example(Note = "This is a note on a method.")]
        public void TestMethod([Example] object arg)
        {
        }

        public static void ShowAttributeData(
            IList<CustomAttributeData> attributes)
        {
            foreach (CustomAttributeData cad in attributes)
            {
                Console.WriteLine("   {0}", cad);
                Console.WriteLine("      Constructor: '{0}'", cad.Constructor);

                Console.WriteLine("      Constructor arguments:");
                foreach (CustomAttributeTypedArgument cata
                    in cad.ConstructorArguments)
                {
                    ShowValueOrArray(cata);
                }

                Console.WriteLine("      Named arguments:");
                foreach (CustomAttributeNamedArgument cana
                    in cad.NamedArguments)
                {
                    Console.WriteLine("         MemberInfo: '{0}'",
                        cana.MemberInfo);
                    ShowValueOrArray(cana.TypedValue);
                }
            }
        }

        private static void ShowValueOrArray(CustomAttributeTypedArgument cata)
        {
            if (cata.Value.GetType() == typeof(ReadOnlyCollection<CustomAttributeTypedArgument>))
            {
                Console.WriteLine("         Array of '{0}':", cata.ArgumentType);

                foreach (CustomAttributeTypedArgument cataElement in
                    (ReadOnlyCollection<CustomAttributeTypedArgument>)cata.Value)
                {
                    Console.WriteLine("             Type: '{0}'  Value: '{1}'",
                        cataElement.ArgumentType, cataElement.Value);
                }
            }
            else
            {
                Console.WriteLine("         Type: '{0}'  Value: '{1}'",
                    cata.ArgumentType, cata.Value);
            }
        }


        public static void Main()
        {
            Assembly asm = Assembly.ReflectionOnlyLoad("RelflectionDemo_将程序集加载到仅反射上下文中");
            Type t = asm.GetType("Test");

            if (t==null)
            {
                var types = asm.DefinedTypes;
                foreach (var typeInfo in types)
                {
                    if (typeInfo.Name.Contains("Test1"))
                    {
                        t = typeInfo;
                    }
                }
            }

            MethodInfo m = t.GetMethod("TestMethod");
            ParameterInfo[] p = m.GetParameters();

            Console.WriteLine("\r\nAttributes for assembly: '{0}'", asm);
            ShowAttributeData(CustomAttributeData.GetCustomAttributes(asm));
            Console.WriteLine("\r\nAttributes for type: '{0}'", t);
            ShowAttributeData(CustomAttributeData.GetCustomAttributes(t));
            Console.WriteLine("\r\nAttributes for member: '{0}'", m);
            ShowAttributeData(CustomAttributeData.GetCustomAttributes(m));
            Console.WriteLine("\r\nAttributes for parameter: '{0}'", p);
            ShowAttributeData(CustomAttributeData.GetCustomAttributes(p[0]));
        }
    }
}
