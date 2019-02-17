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
    public class Controller : ControllerBase, IDisposable
    {
        public void Dispose()
        {
            //throw new NotImplementedException();
        }
        
        public override void Execute(MyRouteData routeData)
        {
            #region V2.0
            ////反射得到Action方法
            //var typeController = this.GetType();
            //var actionName= requestContext.RouteData.GetRequiredString("action");
            ////执行该Action方法
            //var methodInfo = typeController.GetMethod(actionName);
            //methodInfo.Invoke(this, new object[] { });
            #endregion

            #region V3.0
            //1.得到当前控制器的类型
            Type type = this.GetType();
            //2.从路由表中取到当前请求的action名称
            string actionName = routeData.RouteValue["action"].ToString();

            //3.从路由表中取到当前请求的Url参数
            object parameter = null;
            if (routeData.RouteValue.ContainsKey("parameters"))
            {
                parameter = routeData.RouteValue["parameters"];
            }
            var paramTypes = new List<Type>();
            List<object> parameters = new List<object>();
            if (parameter != null)
            {
                var dicParam = (Dictionary<string, string>)parameter;
                foreach (var pair in dicParam)
                {
                    parameters.Add(pair.Value);
                    paramTypes.Add(pair.Value.GetType());
                }
            }

            //4.通过action名称和对应的参数反射对应方法。
            //这里第二个参数可以不理会action字符串的大小写，第四个参数决定了当前请求的action的重载参数类型
            System.Reflection.MethodInfo mi = type.GetMethod(actionName,
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase, null, paramTypes.ToArray(), null);

            //5.执行该Action方法
            mi.Invoke(this, parameters.ToArray());//调用方法
            #endregion
        }
    }
}
