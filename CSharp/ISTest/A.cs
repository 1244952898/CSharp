using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.ISTest
{
    internal class A: IIsA
    {
        public void M0()
        {
            Console.WriteLine(11111111111);
        }

        public void M1(int s)
        {
            Console.WriteLine(s);
        }
    }
}
