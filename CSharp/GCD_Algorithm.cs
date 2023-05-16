using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    class GCD_Algorithm
    {
        public static int Gcd(int m, int n)
        {
            while (m>0)
            {
                var c = n % m;
                n = m;
                m = c;

            }
            return n;
        }
    }
}
