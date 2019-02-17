using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewMVC.Routing
{
    public class MyRoute
    {
        public MyRoute()
        { }

        //在全局配置里面写入路由规则以及默认配置
        public MyRoute(string url, Dictionary<string, object> defaultPath, IMyRouteHandler routeHandler)
        {
            TemplateUrl = url;
            DefaultPath = defaultPath;
            RouteHandler = routeHandler;
        }
        /// <summary>
        /// 
        /// </summary>
        public string TemplateUrl { get; set; }
        /// <summary>
        /// mvcHander处理器
        /// </summary>
        public IMyRouteHandler RouteHandler { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, object> DefaultPath { get; set; }
    }
}
