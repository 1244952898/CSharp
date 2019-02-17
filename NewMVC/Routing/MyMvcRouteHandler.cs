using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;

namespace NewMVC.Routing
{
    public class MyMvcRouteHandler : IMyRouteHandler
    {
        /// <summary>
        /// 返回处理当前请求的HttpHandler对象
        /// </summary>
        /// <param name="routeData">当前的请求的路由对象</param>
        /// <param name="context">当前请求的下文对象</param>
        /// <returns>处理请求的HttpHandler对象</returns>
        public System.Web.IHttpHandler GetHttpHandler(MyRouteData routeData, HttpContextBase context)
        {
            return new MyMvcHandler(routeData, context);
        }
    }
}
