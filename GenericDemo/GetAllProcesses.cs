using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDemo
{
    public class GetAllProcesses: IOperation<Process>
    {
        public IEnumerable<Process> Excute(IEnumerable<Process> input)
        {
            return Process.GetProcesses();
        }
    }
}
