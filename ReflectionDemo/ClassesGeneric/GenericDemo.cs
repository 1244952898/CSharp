using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo.ClassesGeneric
{
    public class GenericDemo<T>
    {
        public GenericDemo()
        {
            Console.WriteLine("GenericDemo Instance");
        }

        public void GenericParameterMethod(T t)
        {
            Console.WriteLine("GenericParameterMethod");
        }
        public void GenericMethod<TV>(TV t)
        {
            List<TV> sVs = new List<TV>();
            Console.WriteLine("GenericMethod");
        }

        public void GenericMethod<TV>()
        {
            List<TV> sVs=new List<TV>();
            Console.WriteLine("GenericMethodWithNo");
        }

        public void Method(int t)
        {
            Console.WriteLine("Method");
        }
    }
}
