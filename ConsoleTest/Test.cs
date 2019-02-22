using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    public class Test : ITest2
    {
        public bool Allow => true;
    }

    public class A {}

    public class B:A { }
}
