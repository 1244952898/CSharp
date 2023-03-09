using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    public class Class1
    {
        public Class1()
        {
            class1s = new List<Class1>();
        }
        public string name1 { get; set; }
        public string name2 { get; set; }
        public List<Class1> class1s { get; set; }

        public void T(int a)
        {
            int b = a, c, d;
            //Console.WriteLine($"${a},${b},${c},${d}");
        }
    }
}
