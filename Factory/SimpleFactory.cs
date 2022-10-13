using IBLL;
using System;
using System.Reflection;

namespace Factory
{
    public class SimpleFactory
    {
        public static IStudent CreateStudent()
        {
            var assmbely = Assembly.LoadFrom("BLL.dll");
            var type = assmbely.GetType("BLL.Student");
            return (IStudent)Activator.CreateInstance(type);
        }
    }
}
