using IBLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class ServiceB: IServiceB
    {
        public ServiceB()
        {
            Console.WriteLine($"{this.GetType().Name}被构造");
        }
    }
}
