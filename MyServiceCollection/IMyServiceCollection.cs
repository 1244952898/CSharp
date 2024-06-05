using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyServiceCollection
{
    public interface IMyServiceCollection : IList<MyServiceDescriptor>
    {
    }
}
