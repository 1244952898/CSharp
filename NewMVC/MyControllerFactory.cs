using NewMVC.Routing;
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
        public IController CreateController(MyRouteData routeData, string controllerName)
        {
            if(routeData == null)
            {
                throw new ArgumentNullException("MyRouteData");
            }

            if (string.IsNullOrEmpty(controllerName))
            {
                throw new ArgumentException("controllerName");
            }

            //得到当前的控制类型
            Type controllerType = GetControllerType(routeData, controllerName);
            if (controllerType == null)
            {
                return null;
            }

            //得到控制器对象
            IController controller = GetControllerInstance(controllerType);
            return controller;
        }

        private IController GetControllerInstance(Type controllerType)
        {
            return Activator.CreateInstance(controllerType) as IController;
        }

        private Type GetControllerType(MyRouteData routeData, string controllerName)
        {
            //从路由配置信息里面读取命名空间和程序集
            object routeNamespaces;
            object routeAssembly;
            routeData.RouteValue.TryGetValue("namespaces",out routeNamespaces);
            routeData.RouteValue.TryGetValue("assembly", out routeAssembly);

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
