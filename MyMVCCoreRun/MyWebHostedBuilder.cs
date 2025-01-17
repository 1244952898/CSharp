using Microsoft.Extensions.Hosting;

namespace MyMVCCoreRun
{
    public class MyWebHostedBuilder
    {
        public IHostBuilder HostBuilder { get; }
        public IApplicationBuilder ApplicationBuilder { get; }
        public MyWebHostedBuilder(IHostBuilder hostBuilder, IApplicationBuilder applicationBuilder)
        {
            HostBuilder = hostBuilder;
            ApplicationBuilder = applicationBuilder;
        }
    }
}
