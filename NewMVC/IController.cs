﻿using NewMVC.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace NewMVC
{
    public interface IController
    {
        void Execute(MyRouteData routeData);
    }
}
