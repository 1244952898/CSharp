using Microsoft.Extensions.Hosting;

namespace _10服务承载
{
    public class PerformanceMetricsCollector : IHostedService
    {
        private IDisposable _scheduler;
        private IProcessorMetricsCollector _processorMetricsCollector;
        private IMemoryMetricsCollector _memoryMetricsCollector;
        private INetworkMetricsCollector _networkMetricsCollector;
        private IMetricsDeliverer _metricsDeliverer;

        public PerformanceMetricsCollector(IProcessorMetricsCollector processorMetricsCollector,
          IMemoryMetricsCollector memoryMetricsCollector,
          INetworkMetricsCollector networkMetricsCollector,
          IMetricsDeliverer metricsDeliverer)
        {
            _processorMetricsCollector = processorMetricsCollector;
            _memoryMetricsCollector = memoryMetricsCollector;
            _networkMetricsCollector = networkMetricsCollector;
            _metricsDeliverer = metricsDeliverer;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _scheduler = new Timer(Callback, null, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
        }
        static void Callback(object? state)
        {
            PerformanceMetrics performanceMetrics = PerformanceMetrics.Create();
            Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss} {performanceMetrics}]");
            Console.WriteLine("--------------------");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _scheduler?.Dispose();
            return Task.CompletedTask;
        }
    }
}
