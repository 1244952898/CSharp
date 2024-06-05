using System;
using System.Linq;

namespace MyServiceCollection
{
    public interface IMyServiceCollection : IList<MyServiceDescriptor>
    {
    }
}
