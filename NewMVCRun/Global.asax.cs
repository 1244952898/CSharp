using NewMVC;
using NewMVC.Routing;
using System;
using System.Collections.Generic;

namespace NewMVCRun
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            var defaultPath = new Dictionary<string, object>
            {
                { "controller", "Home" },
                { "action", "Index" },
                { "id", null },
                { "namespaces", "NewMVCRun.Controllers" },
                { "assembly", "NewMVCRun" }
            };

            MyRouteTable.Routes.Add("defaultRoute", new MyRoute("{controller}/{action}/{id}", defaultPath,new MyMvcRouteHandler()));

            //RouteTable.Routes.Add("defaultRoute", 
            //    new Route("{controller}/{action}/{id}", 
            //    new RouteValueDictionary(
            //        new {
            //            controller = "Home",
            //            action = "Index",
            //            id = "",
            //            namespaces = "NewMVCRun.Controllers",
            //            assembly = "NewMVCRun"
            //        }),
            //    new MyMvcRouteHandler()));

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}