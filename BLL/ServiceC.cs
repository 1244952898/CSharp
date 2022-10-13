using IBLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class ServiceC: IServiceC
    {
        public ServiceC()
        {
            Console.WriteLine($"{this.GetType().Name}被构造");
        }
    }
}
