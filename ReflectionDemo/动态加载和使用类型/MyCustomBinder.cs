using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo.构造泛型类型的实例
{
    public class MyCustomBinder:Binder
    {
        public override MethodBase BindToMethod(BindingFlags bindingAttr, MethodBase[] match, ref object[] args, ParameterModifier[] modifiers,
            CultureInfo culture, string[] names, out object state)
        {
            Console.WriteLine("BindToMethod");

            if (match==null)
            {
                throw new ArgumentNullException("BindToMethod--------mehtod");
            }

            state = null;

            foreach (var mb in match)
            {
                ParameterInfo[] parameters = mb.GetParameters();

                if (ParametersMatch(parameters, args))
                {
                    return mb;
                }
            }
            return null;
        }

        private bool ParametersMatch(ParameterInfo[] a, object[] b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i].ParameterType != b[i].GetType())
                {
                    return false;
                }
            }
            return true;
        }

        private bool ParametersMatch(ParameterInfo[] parameters, Type[] types)
        {
            if (parameters.Length!=types.Length)
            {
                return false;
            }

            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i].ParameterType!=types[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override FieldInfo BindToField(BindingFlags bindingAttr, FieldInfo[] match, object value, CultureInfo culture)
        {
            Console.WriteLine("BindToField");

            if (match==null)
            {
                throw new ArgumentNullException("BindToField------match");
            }

            foreach (FieldInfo fieldInfo in match)
            {
                if (FieldMatch(fieldInfo,value))
                {
                    return fieldInfo;
                }
            }

            return null;
        }

        private bool FieldMatch(FieldInfo fieldInfo, object value)
        {
            Console.WriteLine("FieldMatch");
            return fieldInfo.FieldType == value.GetType();
        }

        public override MethodBase SelectMethod(BindingFlags bindingAttr, MethodBase[] match, Type[] types, ParameterModifier[] modifiers)
        {
            Console.WriteLine("SelectMethod");
            if (match == null)
            {
                throw new ArgumentNullException("match");
            }

            // Find a parameter match and return the first method with
            // parameters that match the request.
            foreach (MethodBase mb in match)
            {
                ParameterInfo[] parameters = mb.GetParameters();
                if (ParametersMatch(parameters, types))
                {
                    return mb;
                }
            }

            return null;
        }

        public override PropertyInfo SelectProperty(BindingFlags bindingAttr, PropertyInfo[] match, Type returnType, Type[] indexes,
            ParameterModifier[] modifiers)
        {
            Console.WriteLine("SelectProperty");
            if (match == null)
            {
                throw new ArgumentNullException("SelectProperty-----match");
            }
            foreach (PropertyInfo pi in match)
            {
                if (pi.GetType() == returnType &&
                    ParametersMatch(pi.GetIndexParameters(), indexes))
                {
                    return pi;
                }
            }
            return null;
        }

        public override object ChangeType(object value, Type type, CultureInfo culture)
        {
            Console.WriteLine("ChangeType");
            try
            {
                object newType;
                newType = Convert.ChangeType(value, type);
                return newType;
            }
            // Throw an InvalidCastException if the conversion cannot
            // be done by the Convert.ChangeType method.
            catch (InvalidCastException)
            {
                return null;
            }
        }

        public override void ReorderArgumentArray(ref object[] args, object state)
        {
            Console.WriteLine("ReorderArgumentArray");
            // throw new NotImplementedException();
        }
    }
}
