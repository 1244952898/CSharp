using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDemo
{
    public class LimitByWorkingSetSize:IOperation<Process>
    {
        public IEnumerable<Process> Excute(IEnumerable<Process> input)
        {
            int maxSizeBytes = 50 * 1024 * 1024;
            foreach (var process in input)
            {
                if (process.WorkingSet64>maxSizeBytes)
                {
                    yield return process;
                }
            }

        }
    }
}
