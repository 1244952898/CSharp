using NewMVC.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace NewMVC
{
    //这个类主要定义约束
    public abstract class ControllerBase : IController
    {
        public abstract void Execute(MyRouteData routeData);

        public void Dosome()
        {

        }
    }

    public class ctsd : ControllerBase
    {
        public override void Execute(MyRouteData routeData)
        {
            Dosome();
        }
    }

    public interface IObeserver
    {
        void Method();
    }
}
