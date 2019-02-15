using System;
using System.Collections.Generic;
using System.Linq;
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

        public override void Execute(RequestContext requestContext)
        {
            //反射得到Action方法
            var typeController = this.GetType();
            var actionName= requestContext.RouteData.GetRequiredString("action");
            //执行该Action方法
            var methodInfo = typeController.GetMethod(actionName);
            methodInfo.Invoke(this, new object[] { });
        }
    }
}
