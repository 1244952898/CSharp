using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;

namespace Blog.Core.ConfigureExtensions
{
    public static class SwaggerExtension
    {
        public static void UserSwaggerSetting(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                var ApiName = configuration["ApiName"]??"Blog.Core";
                var version = configuration["version"] ?? "v1";
                c.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"{ApiName} {version}");
                c.RoutePrefix = "";
            });

        }
    }
}
