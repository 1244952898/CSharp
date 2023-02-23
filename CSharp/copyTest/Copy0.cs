using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.copyTest
{
    internal class Copy0
    {
        public int Age { get;set; }
        public string Name { get; set; }
    }

    internal class Copy1: ICloneable
    {
        public int Num { get; set; }
        public Copy0 C0 { get; set; }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
