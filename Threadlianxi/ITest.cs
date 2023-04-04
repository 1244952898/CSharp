using System;
using System.Collections.Generic;
using System.Text;

namespace Threadlianxi
{
    internal interface ITest
    {
        public void Add()
        {
            Console.WriteLine(1);
        }
    }

    internal class Test : ITest
    {
        public Test()
        {

        }
    }
}
