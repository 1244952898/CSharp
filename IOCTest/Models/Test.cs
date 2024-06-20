using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCTest.Models
{
    internal class Test
    {
        public string Name {  get; set; }

        public Test()
        {
            
        }
        public Test(string name)
        {
            Name = name;
        }
    }


}
