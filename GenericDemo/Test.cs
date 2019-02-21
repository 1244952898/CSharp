using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDemo
{
    public class Test<T,U> where T:new() where U:class,T, new()
    {
    }
}
