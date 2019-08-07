using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Self_HostOWIN;

namespace Self_HostOWIN
{
    public class Startup2
    {
        public void Configuration(IAppBuilder app)
        { 
            // New code: Add the error page middleware to the pipeline. 
            app.UseErrorPage();
            // 有关如何配置应用程序的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkID=316888
            app.Run(context =>
            {
                // New code: Throw an exception for this URI path.
                if (context.Request.Path.Equals(new PathString("/fail")))
                {
                    throw new Exception("Random exception");
                }

                context.Response.ContentType = "text/plain";
                return context.Response.WriteAsync("Hello World!--------------2");
            });
        }
    }
}
