using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.TestInterface2
{
    public class IntefaceClass : Interface1, Interface2
    {
        public void F()
        {
        }

        void Interface1.F()
        {

        }
        void Interface2.F()
        {

        }
    }
}
