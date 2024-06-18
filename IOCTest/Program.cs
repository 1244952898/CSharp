// See https://aka.ms/new-console-template for more information
using IOCTest.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

#region 3
var serviceProvider = new ServiceCollection()
    .AddSingleton<SingletonService>()
    .AddScoped<ScopeService>()
    .BuildServiceProvider();
var rootScope = serviceProvider.GetService<IServiceProvider>();
using var scope=serviceProvider.CreateScope();
var childer=scope.ServiceProvider;
var singletonService=childer.GetService<SingletonService>();
var scopeService=childer.GetService<ScopeService>();
Debug.Assert(ReferenceEquals(childer, scopeService.RequestProvider));
Debug.Assert(ReferenceEquals(rootScope, singletonService.ApplicationService));

#endregion

#region MyRegion
//Cat cat = new();
//cat.Register<IFoo, Foo>(CatLifetime.Transient)
//    .Register<IBar>(_=new Bar());

#endregion

#region 2
//var serviceCollection=new ServiceCollection();
//serviceCollection.AddTransient<Base, Bar>();
//serviceCollection.AddTransient<Base, Foo>();
//serviceCollection.AddTransient<Base, Baz>();
//serviceCollection.AddSingleton<Base, Bar>();
//serviceCollection.AddSingleton(new Bar());
//serviceCollection.AddTransient<Base, Bar>();

//var serviceProvider=serviceCollection.BuildServiceProvider();
//var a = (IEnumerable<Base>)serviceProvider.GetService(typeof(IEnumerable<Base>));

//var alst=a.OfType<Bar>();
//var c =alst.Count();


//var b =serviceProvider.GetService<Base>();
//var bases =serviceProvider.GetServices(typeof(Base));
//var bases2 = serviceProvider.GetRequiredService(typeof(IEnumerable<Base>));
#endregion

#region 1

//BuildServiceProvider(true);
//BuildServiceProvider(false);

//static void BuildServiceProvider(bool validateOnBuild)
//{
//	try
//	{
//		var options = new ServiceProviderOptions
//		{
//			ValidateOnBuild = validateOnBuild
//		};
//		var services = new ServiceCollection()
//			.AddSingleton<IFooBar,FooBar>()
//			.BuildServiceProvider(options);
//		Console.WriteLine($"Status:Success; ValidateOnBuild:{validateOnBuild}");
//	}
//	catch (Exception ex)
//	{
//        Console.WriteLine($"Status:Fail; ValidateOnBuild:{validateOnBuild}");
//        Console.WriteLine($"Error:{ex.Message}");
//    }
//}

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
var root = new ServiceCollection().BuildServiceProvider(true);
#endregion

Console.WriteLine("Hello, World!");