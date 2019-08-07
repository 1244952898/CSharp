using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(_5KatanaHostAuth.Startup))]

namespace _5KatanaHostAuth
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpListener listener =
                (HttpListener)app.Properties["System.Net.HttpListener"];
            listener.AuthenticationSchemes =
                AuthenticationSchemes.IntegratedWindowsAuthentication;

            app.Run(context =>
            {
                context.Response.ContentType = "text/plain";
                return context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
