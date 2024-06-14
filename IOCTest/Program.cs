// See https://aka.ms/new-console-template for more information
using IOCTest.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

Console.WriteLine("Hello, World!");

#region 1

BuildServiceProvider(true);
BuildServiceProvider(false);

static void BuildServiceProvider(bool validateOnBuild)
{
	try
	{
		var options = new ServiceProviderOptions
		{
			ValidateOnBuild = validateOnBuild
		};
		var services = new ServiceCollection()
			.AddSingleton<IFooBar,FooBar>().TryAdd()
			.BuildServiceProvider(options);
		Console.WriteLine($"Status:Success; ValidateOnBuild:{validateOnBuild}");
	}
	catch (Exception ex)
	{
        Console.WriteLine($"Status:Fail; ValidateOnBuild:{validateOnBuild}");
        Console.WriteLine($"Error:{ex.Message}");
    }
}

#endregion

#region 0

//var root = new ServiceCollection()
//    .AddSingleton<IFoo, Foo>()
//    .AddScoped<IBar, Bar>()
//    .BuildServiceProvider(true);
//var child = root.CreateScope().ServiceProvider;
//void ResolveService<T>(IServiceProvider provider)
//{
//    var isRootContainer = root == provider ? "Yes" : "No";
//    try
//    {
//        provider.GetService<T>();
//        Console.WriteLine($"Status:Success; Service Type {typeof(T).Name}; Root:{isRootContainer}");
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine($"Status:Fail; Service Type {typeof(T).Name}; Root:{isRootContainer}");
//        Console.WriteLine($"Error:{ex.Message}");
//    }
//}

//ResolveService<IFoo>(root);
//ResolveService<IBar>(root);
//ResolveService<IFoo>(child);
//ResolveService<IBar>(child);

#endregion