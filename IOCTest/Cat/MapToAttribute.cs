using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOCTest.Cat
{
    [AttributeUsage(AttributeTargets.Class,AllowMultiple =true)]
    public class MapToAttribute : Attribute
    {
        public Type ServiceType { get; }
        public CatLifetime Lifetime { get; }
        public MapToAttribute(Type serviceType, CatLifetime catLifetime)
        {
            ServiceType=serviceType;
            Lifetime=catLifetime;
        }
    }
}
