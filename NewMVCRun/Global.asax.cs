using NewMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace NewMVCRun
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.Add("defaultRoute", 
                new Route("{controller}/{action}/{id}", 
                new RouteValueDictionary(
                    new {
                        controller = "Home",
                        action = "Index",
                        id = "",
                        namespaces = "NewMVCRun.Controllers",
                        assembly = "NewMVCRun"
                    }),
                new MyMvcRouteHandler()));
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