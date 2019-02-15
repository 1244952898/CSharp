﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;

namespace NewMVC.Routing
{
    public interface IRouteHandler
    {
        IHttpHandler GetHttpHandler(RouteData routeData, HttpContextBase context);
    }
}
