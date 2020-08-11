using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VueDemo.Controllers
{
    public class IViewController : Controller
    {
        // GET: IView
        public ActionResult Test0()
        {
            return View();
        }
    }
}