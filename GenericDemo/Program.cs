using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<string> sList=new GenericList<string>();
            sList.AddItem("a");
            sList.AddItem("b");
            sList.AddItem("c");
            sList.AddItem("d");
            sList.AddItem("e");

            // ReSharper disable once GenericEnumeratorNotDisposed
            foreach (var data in sList)
            {
                Console.WriteLine(data);
            }
            Console.ReadKey();
        }
    }
}
