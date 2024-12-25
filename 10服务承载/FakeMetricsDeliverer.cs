using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10服务承载
{
    public class FakeMetricsDeliverer : IMetricsDeliverer
    {
        public Task DeliverAsync(PerformanceMetrics counter)
        {
            Console.WriteLine($"{DateTime.Now:yyyy-MM-dd hh:mm:ss} {counter}");
            return Task.CompletedTask;
        }
    }
}
