// See https://aka.ms/new-console-template for more information

using _10服务承载;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


//Test2 test2 = new();
//test2.Run(new Test1());
FakeMetricsCollector collector = new ();
new HostBuilder()
    //.ConfigureHostConfiguration(builder =>
    //{
    //    builder.AddCommandLine(args);
    //})
    //.ConfigureAppConfiguration((context, builder) =>
    //{
    //    //builder.AddJsonFile("");
    //})
    .ConfigureServices((context, services) =>
    {
        //services.AddSingleton<IHostedService, PerformanceMetricsCollector>();
        //services.AddSingleton<IProcessorMetricsCollector, FakeMetricsCollector>();
        //services.AddSingleton<IMemoryMetricsCollector, FakeMetricsCollector>();
        services.AddSingleton<IProcessorMetricsCollector>(collector);
        services.AddSingleton<IMemoryMetricsCollector>(collector);
        services.AddSingleton<INetworkMetricsCollector>(collector);
        services.AddSingleton<IMetricsDeliverer, FakeMetricsDeliverer>();
        services.AddHostedService<PerformanceMetricsCollector>();
    })
    .Build()
    .Run();
