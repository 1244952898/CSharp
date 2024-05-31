using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var lst=new List<string>();
            lst.Where(x => x.Equals("a")).Select(x=>x=="");
        }
    }
}
