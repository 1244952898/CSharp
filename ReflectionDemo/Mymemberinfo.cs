using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo
{
    public class Mymemberinfo
    {
        public static void GMain()
        {
            Type myType = Type.GetType("ReflectionDemo.Test");
            MemberInfo[] mymemberinfoarray = myType?.GetMembers();
            Console.WriteLine("\nThere are {0} members in {1}.",
                mymemberinfoarray?.Length??0, myType?.FullName ?? "");
            foreach (var memberInfo in mymemberinfoarray)
            {
                Console.WriteLine(memberInfo.Name + "" + memberInfo);
            }
            Console.WriteLine("======================================");
            if (myType?.IsPublic??false)
            {
                Console.WriteLine("{0} is public.", myType.FullName);
            }
            
        }

        public static int MethodInfoMain()
        {
            Console.WriteLine("Reflection.MethodInfo");
            // Gets and displays the Type.
            Type MyType = Type.GetType("System.Reflection.FieldInfo");
            // Specifies the member for which you want type information.
            MethodInfo Mymethodinfo = MyType.GetMethod("GetValue");
            Console.WriteLine(MyType.FullName + "." + Mymethodinfo.Name);
            // Gets and displays the MemberType property.
            MemberTypes Mymembertypes = Mymethodinfo.MemberType;
            if (MemberTypes.Constructor == Mymembertypes)
            {
                Console.WriteLine("MemberType is of type All");
            }
            else if (MemberTypes.Custom == Mymembertypes)
            {
                Console.WriteLine("MemberType is of type Custom");
            }
            else if (MemberTypes.Event == Mymembertypes)
            {
                Console.WriteLine("MemberType is of type Event");
            }
            else if (MemberTypes.Field == Mymembertypes)
            {
                Console.WriteLine("MemberType is of type Field");
            }
            else if (MemberTypes.Method == Mymembertypes)
            {
                Console.WriteLine("MemberType is of type Method");
            }
            else if (MemberTypes.Property == Mymembertypes)
            {
                Console.WriteLine("MemberType is of type Property");
            }
            else if (MemberTypes.TypeInfo == Mymembertypes)
            {
                Console.WriteLine("MemberType is of type TypeInfo");
            }
            return 0;
        }

        public static void MainAll()
        {
            // Specifies the class.
            Type t = typeof(System.IO.BufferedStream);
            Console.WriteLine("Listing all the members (public and non public) of the {0} type", t);

            // Lists static fields first.
            FieldInfo[] fi = t.GetFields(BindingFlags.Static |
                BindingFlags.NonPublic | BindingFlags.Public);
            Console.WriteLine("// Static Fields");
            PrintMembers(fi);

            // Static properties.
            PropertyInfo[] pi = t.GetProperties(BindingFlags.Static |
                BindingFlags.NonPublic | BindingFlags.Public);
            Console.WriteLine("// Static Properties");
            PrintMembers(pi);

            // Static events.
            EventInfo[] ei = t.GetEvents(BindingFlags.Static |
                BindingFlags.NonPublic | BindingFlags.Public);
            Console.WriteLine("// Static Events");
            PrintMembers(ei);

            // Static methods.
            MethodInfo[] mi = t.GetMethods(BindingFlags.Static |
                BindingFlags.NonPublic | BindingFlags.Public);
            Console.WriteLine("// Static Methods");
            PrintMembers(mi);

            // Constructors.
            ConstructorInfo[] ci = t.GetConstructors(BindingFlags.Instance |
                BindingFlags.NonPublic | BindingFlags.Public);
            Console.WriteLine("// Constructors");
            PrintMembers(ci);

            // Instance fields.
            fi = t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic |
                BindingFlags.Public);
            Console.WriteLine("// Instance Fields");
            PrintMembers(fi);

            // Instance properites.
            pi = t.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic |
                BindingFlags.Public);
            Console.WriteLine("// Instance Properties");
            PrintMembers(pi);

            // Instance events.
            ei = t.GetEvents(BindingFlags.Instance | BindingFlags.NonPublic |
                BindingFlags.Public);
            Console.WriteLine("// Instance Events");
            PrintMembers(ei);

            // Instance methods.
            mi = t.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic
                | BindingFlags.Public);
            Console.WriteLine("// Instance Methods");
            PrintMembers(mi);

            Console.WriteLine("\r\nPress ENTER to exit.");
            Console.Read();
        }

        public static void PrintMembers(MemberInfo[] ms)
        {
            foreach (MemberInfo m in ms)
            {
                Console.WriteLine("{0}{1}", "     ", m);
            }
            Console.WriteLine();
        }

    }
}
