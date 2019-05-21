using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin;
using Microsoft.Owin.Extensions;
using Owin;

[assembly: OwinStartup(typeof(_6owin2.Startup))]

namespace _6owin2
{
    public class Startup
    {
        //public void Configuration(IAppBuilder app)
        //{
        //    // 有关如何配置应用程序的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkID=316888
        //    app.Use((context, next) =>
        //    {
        //        PrintCurrentIntegratedPipelineStage(context, "Middleware 1");
        //        return next.Invoke();
        //    });
        //    app.Use((context, next) =>
        //    {
        //        PrintCurrentIntegratedPipelineStage(context, "2nd MW");
        //        return next.Invoke();
        //    });
        //    app.Run(context =>
        //    {
        //        PrintCurrentIntegratedPipelineStage(context, "3rd MW");
        //        return context.Response.WriteAsync("Hello world");
        //    });
        //}

        public void Configuration(IAppBuilder app)
        {
            app.Use((context, next) =>
            {
                PrintCurrentIntegratedPipelineStage(context, "Middleware 1");
                return next.Invoke();
            });
            app.Use((context, next) =>
            {
                PrintCurrentIntegratedPipelineStage(context, "2nd MW");
                return next.Invoke();
            });
            app.UseStageMarker(PipelineStage.Authenticate);
            app.Run(context =>
            {
                PrintCurrentIntegratedPipelineStage(context, "3rd MW");
                return context.Response.WriteAsync("Hello world");
            });
            app.UseStageMarker(PipelineStage.ResolveCache);
        }

        private void PrintCurrentIntegratedPipelineStage(IOwinContext context, string msg)
        {
            var currentIntegratedpipelineStage = HttpContext.Current.CurrentNotification;
            context.Get<TextWriter>("host.TraceOutput").WriteLine(
                "Current IIS event: " + currentIntegratedpipelineStage
                + " Msg: " + msg);
        }

    }
}
