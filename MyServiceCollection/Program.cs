// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyServiceCollection;
using MyServiceCollection.Test;


HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddTransient<IA, A>();

var serviceProvider= builder.Services.BuildServiceProvider();

var a =serviceProvider.GetService<IA>();
a.AA();
