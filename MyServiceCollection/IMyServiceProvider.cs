using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyServiceCollection
{
    public interface IMyServiceProvider
    {
        object? GetService(Type serviceType);
    }
}
