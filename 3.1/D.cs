using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._1
{
    public interface ID
    {
        void DConsole();
    }
    public class D : ID
    {
        public void DConsole() 
        {
            Console.WriteLine("0");
        }
    }
    public class D1 : ID
    {
        public void DConsole()
        {
            Console.WriteLine("1");
        }
    }
}
