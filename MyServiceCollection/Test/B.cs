using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyServiceCollection.Test
{
    public class B
    {
        private readonly IA _a;
        public B(IA a)
        {

            this._a = a;
        }
    }
}
