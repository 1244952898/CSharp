using System;
using System.Linq;

namespace MyServiceCollection
{
    public interface IMyServiceProvider
    {
        object? GetService(Type serviceType);
    }
}
