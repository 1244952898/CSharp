namespace _10服务承载
{
    public class FakeMetricsCollector : IProcessorMetricsCollector, IMemoryMetricsCollector, INetworkMetricsCollector
    {
        public FakeMetricsCollector()
        {
            Console.WriteLine("Create FakeMetricsCollector");
        }
        long IMemoryMetricsCollector.GetUsage()
        {
            return PerformanceMetrics.Create().Memory;
        }

        long INetworkMetricsCollector.GetUsage()
        {
            return PerformanceMetrics.Create().Network;
        }

        int IProcessorMetricsCollector.GetUsage()
        {
            return PerformanceMetrics.Create().Processor;
        }
    }
}
