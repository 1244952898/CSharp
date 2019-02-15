using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace NewMVC
{
    public class MyControllerFactory : IControllerFactory
    {
        //通过当前的请求上下文和控制器名称得到控制器的对象
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            if(requestContext == null)
            {
                throw new ArgumentNullException("requestContext");
            }

            if (string.IsNullOrEmpty(controllerName))
            {
                throw new ArgumentException("controllerName");
            }

            //得到当前的控制类型
            Type controllerType = GetControllerType(requestContext, controllerName);
            if (controllerType == null)
            {
                return null;
            }

            //得到控制器对象
            IController controller = GetControllerInstance(requestContext, controllerType);
            return controller;
        }

        private IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return Activator.CreateInstance(controllerType) as IController;
        }

        private Type GetControllerType(RequestContext requestContext, string controllerName)
        {
            //从路由配置信息里面读取命名空间和程序集
            object routeNamespaces;
            object routeAssembly;
            requestContext.RouteData.Values.TryGetValue("namespaces",out routeNamespaces);
            requestContext.RouteData.Values.TryGetValue("assembly", out routeAssembly);

            var type = Assembly.Load(routeAssembly.ToString()).GetType(routeNamespaces.ToString() + "." + controllerName + "Controller");

            return type;
        }

        public void ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}
