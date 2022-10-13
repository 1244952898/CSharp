using IBLL;
using MyIOC_Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class ServiceA: IServiceA
    {
        public IServiceB _IServiceB;

        [PropertyInjectionAttribute]
        public IServiceC iServiceC { get; set; }

        public ServiceA(IServiceB iServiceB)
        {
            _IServiceB = iServiceB;
            Console.WriteLine($"{this.GetType().Name}被构造");
        }
        public ServiceA()
        {
            
        }
    }
}
