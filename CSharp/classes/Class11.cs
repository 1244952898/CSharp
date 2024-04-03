using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp.classes
{
    public class Class11 : Interface1
    {
        public int Name { get; set; }

        public IEnumerable<Class1> GetClass1s(int i)
        {
            if (i==0)
            {
                yield break;
            }
            yield return new Class1() { Name1="1"};
            yield return new Class1() { Name1="2"};
        }
    }
}
