using Consul0.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Consul0
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
           var str = ConsulConfigTest.ConsulTest().GetAwaiter().GetResult();
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
