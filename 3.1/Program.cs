// See https://aka.ms/new-console-template for more information
using _3._1;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.Net.NetworkInformation;



var serP = new ServiceCollection();
serP.AddTransient<IA, A>()
    //.AddTransient<IB, B>()
    .AddTransient(typeof(IC<,>), typeof(C<,>))
    .AddTransient<ID, D>()
    .AddTransient<ID, D1>()
    .AddScoped<IB>(_ =>
    {
        return new B();
    });
var p = serP.BuildServiceProvider();
var tt = (C<IA, IB>)p.GetService<IC<IA, IB>>();

//var ds= p.GetServices<ID>();
//foreach (var d in ds)
//{
//    d.DConsole();
//}
Console.WriteLine("Hello, World!");

CancellationTokenSourceTest t = new();
t.T0();
//HashSet<int> ints = new HashSet<int>();
//ints.