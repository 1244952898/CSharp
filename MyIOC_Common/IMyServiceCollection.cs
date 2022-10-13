using System;
using System.Collections.Generic;
using System.Text;

namespace MyIOC_Common
{
     public interface IMyServiceCollection
    {
        public void AddTransient<TService, TImplementation>() where TImplementation:TService;

        public T GetService<T>() where T :class;


    }
}
