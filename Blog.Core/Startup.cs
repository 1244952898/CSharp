using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.CommandLine;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using System.IO;
using Blog.Core.ConfigureExtensions;
using Swashbuckle.AspNetCore.Filters;

namespace Blog.Core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            #region Swagger

            services.AddMvc();
            services.AddSwaggerGen(setupAction =>
            {
                //开启加权小锁
                setupAction.OperationFilter<AddResponseHeadersFilter>();
                setupAction.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

                //header加token
                setupAction.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

                setupAction.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT(授权) 再 bear token加空格",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                setupAction.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v0.1.0",
                    Title = "Blog.Core API",
                    Description = "框架说明文档",
                    //TermsOfService = "None",
                    Contact = new OpenApiContact
                    {
                        Name = "Blog.Core",
                        Email = "Blog.Core@xxx.com",
                        Url = new Uri("https://www.jianshu.com/u/94102b59cc2a")
                    }
                });

                var filePath = Path.Combine(System.AppContext.BaseDirectory, "Blog.Core.xml");
                setupAction.IncludeXmlComments(filePath, true);

                var xmlModelPath = Path.Combine(AppContext.BaseDirectory, "Blog.Core.Model.xml");
                setupAction.IncludeXmlComments(xmlModelPath);

            });

            #endregion

            #region 注释
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            //});
            //services.AddMvc(options =>
            //{
            //    options.ReturnHttpNotAcceptable=true;
            //    options.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            //});
            //services.Configure<GenericWebHostServiceOptions>(options => { });
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IConfiguration configuration)
        {
            //configurationBuilder.Add(new CommandLineConfigurationSource { Args = { }, });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            #region Swagger

            app.UserSwaggerSetting(configuration);

            #endregion
        }
    }
}
