using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10服务承载
{
    internal class Test2
    {
        public void Run(object t)
        {
            ITest test = (ITest)t;
            test.Run();
        }
    }
}
