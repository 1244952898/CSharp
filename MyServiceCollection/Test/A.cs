using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyServiceCollection.Test
{
    public class A : IA
    {
        public void AA()
        {
            Console.WriteLine($"this is type of {this.GetType().Name}");
        }
    }
}
