using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPI全局错误日志自动记录.App_Start;
using WebAPI全局错误日志自动记录.Filters;

namespace WebAPI全局错误日志自动记录
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            config.Filters.Add(new GlobalFiltersConfig());
            
            //配置cross-origin resource sharing(cors 跨域资源共享)
            var origins = ConfigurationManager.AppSettings["cors:allowOrigins"]??"*";
            var allowHeaders = ConfigurationManager.AppSettings["cors:allowHeaders"] ?? "*";
            var allowMethods = ConfigurationManager.AppSettings["cors:allowMethods"] ?? "*";
            var cors = new EnableCorsAttribute(origins, allowHeaders, allowMethods);
            config.EnableCors(cors);


            //配置JWT
            // config.JWTAuthConfiguration(config);

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
