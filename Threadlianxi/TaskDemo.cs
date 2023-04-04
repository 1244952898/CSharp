using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Threadlianxi
{
    internal class TaskDemo
    {
        public void M()
        {
            Task<int> t = new Task<int>(() =>
            {
                return 1;
            });
            t.GetAwaiter().GetResult();
            var a = t.Result;
        }
    }
}
