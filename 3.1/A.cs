using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1
{
    public interface IA
    {

    }
    internal class A: IA
    {
        public Func<B, Type[],object> Func;
        public A(Func<B, Type[], object> f)
        {
            Func = f;
        }
    }
}
