using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    public interface ITest1
    {
        bool Allow { get; }
    }

    public interface ITest2:ITest1
    {
    }
}
