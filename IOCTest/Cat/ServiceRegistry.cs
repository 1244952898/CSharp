using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCTest.Cat
{
    public class ServiceRegistry
    {
        public Type ServiceType { get; set; }
        public CatLifetime Lifetime { get; set; }
        public Func<Cat, Type[],object> Factory { get; set; }
        public ServiceRegistry next { get; set; }

        public ServiceRegistry(Type serviceType, CatLifetime lifetime, Func<Cat, Type[], object> factory)
        {
            ServiceType=serviceType;
            Lifetime=lifetime;
            Factory=factory;
        }

        public IEnumerable<ServiceRegistry> AsEnumerable()
        {
            var list=new List<ServiceRegistry>();
            for(var self = this; self != null; self = self.next)
            {
                list.Add(self);
            }
            return list;
        }
    }
}
