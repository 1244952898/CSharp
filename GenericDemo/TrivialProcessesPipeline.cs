using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDemo
{
    public class TrivialProcessesPipeline: Pipeline<Process>
    {
        public TrivialProcessesPipeline()
        {
            Register(new GetAllProcesses());
            Register(new LimitByWorkingSetSize());
            Register(new PrintProcessName());
        }
    }
}
