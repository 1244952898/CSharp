
internal class Program
{
    private static void Main(string[] args)
    {
        #region Original

        var builder = WebApplication.CreateBuilder(args);

        //// Add services to the container.
        //builder.Services.AddRazorPages();

        //var app = builder.Build();

        //// Configure the HTTP request pipeline.
        //if (!app.Environment.IsDevelopment())
        //{
        //    app.UseExceptionHandler("/Error");
        //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        //    app.UseHsts();
        //}

        //app.UseHttpsRedirection();
        //app.UseStaticFiles();

        //app.UseRouting();

        //app.UseAuthorization();

        //app.MapRazorPages();

        //app.Run();
        #endregion

        #region 11.1
        static RequestDelegate Middleware0(RequestDelegate next)
        {
            return async context =>
            {
                await context.Response.WriteAsync($"Hello");
                await next(context);
            };
        }
        //AppContext.BaseDirectory
        static RequestDelegate Middleware1(RequestDelegate next) =>
         async context =>
         {
             await context.Response.WriteAsync($" world");
         };

        Host.CreateDefaultBuilder()
            .ConfigureWebHostDefaults(builder =>
            {
                builder.Configure(app =>
                {
                    app
                    .Use(Middleware0)
                    .Use(Middleware1);
                });
            })
            
            .Build()
            .Run();

        //WebHostDefaults.ServerUrlsKey
        #endregion
    }
}