using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using System.Web.Caching;

namespace CacheMVCDemo
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //配缓存数据库依赖
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connStr"].ToString();
            //启动数据库的数据缓存依赖功能      
            SqlCacheDependencyAdmin.EnableNotifications(connectionString);
            //启用数据表缓存  
            SqlCacheDependencyAdmin.EnableTableForNotifications(connectionString, "Person"); //第二个参数可以是单个表名或表名的数组
        }
    }
}