using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    delegate void StringAction(B q);
    class Program
    {
        static void Main(string[] args)
        {
            StringAction sa = new StringAction(ActOnObject);
       
           
        }
        static void ActOnObject(A q)  
        {
        }
    }
}
