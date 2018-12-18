using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo.构造泛型类型的实例
{
    // Define an example interface.
    public interface ITestArgument { }

    // Define an example base class.
    public class TestBase { }

    // Define a generic class with one parameter. The parameter
    // has three constraints: It must inherit TestBase, it must
    // implement ITestArgument, and it must have a parameterless
    // constructor.
    public class Test<T> where T : TestBase, ITestArgument, new() { }

    public class Example
    {
        public static void DisplayGenericType(Type t)
        {
            Console.WriteLine("\r\n {0}", t);
            Console.WriteLine("   Is this a generic type? {0}", t.IsGenericType);
            Console.WriteLine("   Is this a generic type definition? {0}",t.IsGenericTypeDefinition);
            Type[] tArguments = t.GetGenericArguments();
            Console.WriteLine("   List {0} type arguments:",tArguments.Length);
            foreach (var tArgument in tArguments)
            {
                if (tArgument.IsGenericParameter)
                {
                    DisplayGenericParameter(tArgument);
                }
                else
                {
                    Console.WriteLine("      Type argument: {0}",tArgument);
                }
            }
        }

        private static void DisplayGenericParameter(Type tp)
        {
            Console.WriteLine("      Type parameter: {0} position {1}",tp,tp.GenericParameterPosition);
            Type classConstraint = tp.BaseType;
            foreach (Type genericParameterConstraint in tp.GetGenericParameterConstraints())
            {
                if (genericParameterConstraint.IsInterface)
                {
                    Console.WriteLine("         Interface constraint: {0}");
                }
            }

            if (classConstraint != null)
            {
                Console.WriteLine("         Base type constraint: {0}",
                    tp.BaseType);
            }
            else
                Console.WriteLine("         Base type constraint: None");

            GenericParameterAttributes sConstraints  = tp.GenericParameterAttributes & GenericParameterAttributes.SpecialConstraintMask;

            if (sConstraints== GenericParameterAttributes.None)
            {
                Console.WriteLine("         No special constraints.");
            }
            else
            {
                if (GenericParameterAttributes.None!=(sConstraints& GenericParameterAttributes.DefaultConstructorConstraint))
                {
                    Console.WriteLine("         Must have a parameterless constructor.");
                }

                if (GenericParameterAttributes.None != (sConstraints & GenericParameterAttributes.ReferenceTypeConstraint))
                {
                    Console.WriteLine("         Must be a reference type.");
                }

                if (GenericParameterAttributes.None != (sConstraints & GenericParameterAttributes.NotNullableValueTypeConstraint))
                {
                    Console.WriteLine("         Must be a non-nullable value type.");
                }
            }

        }
    }
}
