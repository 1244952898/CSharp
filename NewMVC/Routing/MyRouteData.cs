using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewMVC.Routing
{
    public class MyRouteData
    {
        public IRouteHandler RouteHandler { get; set; }

        public Dictionary<string, object> RouteValue { get; set; }
    }
}
