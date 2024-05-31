using EFCoreDemo.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


builder.Services.AddTransient<A0>();
builder.Services.AddTransient<A1>();
builder.Services.AddTransient(serviceProvider =>
{
    IA func(Type key)
    {
        if (key == typeof(A0))
        {
            var service= serviceProvider.GetService<A0>();
            if (service!=null)
            {
                return service;
            }
        }
        else if (key == typeof(A1))
        {
            var service = serviceProvider.GetService<A1>();
            if (service != null)
            {
                return service;
            }
        }
        throw new ArgumentException($"不支持的DI Key: {key}");
    }
    return (Func<Type, IA>)func;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
