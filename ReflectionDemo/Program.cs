using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReflectionDemo.ClassesGeneric;

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

            GenericRelection.GMain();

            Console.ReadKey();
        }
    }
}
