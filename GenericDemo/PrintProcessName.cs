using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDemo
{
    public class PrintProcessName:IOperation<Process>
    {
        public IEnumerable<Process> Excute(IEnumerable<Process> input)
        {
            foreach (var process in input)
            {
               Console.WriteLine(process.ProcessName);
            }
            yield break;
        }
    }
}
