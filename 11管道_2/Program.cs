using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _11管道_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();

            //Host.CreateDefaultBuilder(args)
            // .ConfigureWebHost(builder =>
            // {
            //     builder.Configure(app =>
            //     {
            //         app.Use()
            //         //appBuilder.Run()
            //     });
            // })
            // .Build();
            IServer _server;
            RequestDelegate requestDelegate = (c) =>
            {

                return Task.CompletedTask;
            };
            //_server.StartAsync(requestDelegate);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
