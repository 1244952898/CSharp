using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_文件系统
{
    internal class DataSource:EventSource
    {
        public void Write()
        {
            WriteEvent(1, "a", "b");
        }
    }
}
