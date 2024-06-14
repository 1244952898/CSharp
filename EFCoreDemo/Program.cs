using EFCoreDemo.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EFCoreDemo.Data;
using EFCoreDemo.DbInitializer;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolContext") ?? throw new InvalidOperationException("Connection string 'SchoolContext' not found.")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddTransient<A0>();
builder.Services.AddTransient<A1>();
builder.Services.AddTransient(serviceProvider =>
{
    Func<Type, IA> func = (Type key) =>
    {
        if (key == typeof(A0))
        {
            var service = serviceProvider.GetService<A0>();
            if (service != null)
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
        throw new ArgumentException($"��֧�ֵ�DI Key: {key}");
    };
    return func;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<SchoolContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
