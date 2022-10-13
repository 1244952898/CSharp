using IBLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class Headphone: IHeadphone
    {
        public Headphone()
        {
            Console.WriteLine($"{this.GetType().Name}被构造");
        }
    }
}
