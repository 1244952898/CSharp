﻿using NewMVC.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NewMVC
{
    public class MyMvcHandler : IHttpHandler
    {
        public virtual bool IsReusable
        {
            get { return false; }
        }

        public HttpContextBase myContext { get; set; }
        public MyRouteData MyRouteData { get; set; }

        public MyMvcHandler() { }

        //通过构造函数将两个对象传过来，替代了原来RequestContext的作用
        public MyMvcHandler(MyRouteData routeData, HttpContextBase context)
        {
            MyRouteData = routeData;
            myContext = context;
        }

        public void ProcessRequest(HttpContext context)
        {
            #region V1.0
            //context.Response.Write("当前页面地址：" + context.Request.Url.AbsoluteUri + "    ");
            //context.Response.Write("Hello MVC");
            #endregion

            #region V2.0

            ////步骤1.从上下文的Request.RequestContext中取到RouteData对象。这里和UrlRoutingModule里面的context.Request.RequestContext = requestContext;对应。
            //var routeData = context.Request.RequestContext.RouteData;

            //// 步骤2.从当前的RouteData里面得到请求的控制器名称
            //string controllerName = routeData.GetRequiredString("controller");

            ////步骤3.得到控制器工厂
            //IControllerFactory factory = new MyControllerFactory();

            ////步骤4.通过默认控制器工厂得到当前请求的控制器对象
            //IController controller = factory.CreateController(context.Request.RequestContext, controllerName);
            //if (controller == null)
            //{
            //    return;
            //}

            //try
            //{
            //    //步骤5.执行控制器的Action
            //    controller.Execute(context.Request.RequestContext);
            //}
            //catch
            //{

            //}
            //finally
            //{
            //    //步骤6.释放当前的控制器对象
            //    factory.ReleaseController(controller);
            //}

            #endregion

            #region V3.0
            //1.从当前的RouteData里面得到请求的控制器名称
            string controllerName = MyRouteData.RouteValue["controller"].ToString();

            //2.得到控制器工厂
            IControllerFactory factory = new MyControllerFactory();

            //3.通过默认控制器工厂得到当前请求的控制器对象
            IController controller = factory.CreateController(MyRouteData, controllerName);
            if (controller == null)
            {
                return;
            }
            try
            {
                //4.执行控制器的Action
                controller.Execute(MyRouteData);
            }
            catch
            { }
            finally
            {
                //5.释放当前的控制器对象
                factory.ReleaseController(controller);
            }
            #endregion

        }
    }
}
