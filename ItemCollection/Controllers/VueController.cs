using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ItemCollection.Controllers
{
    public class VueController : Controller
    {
        public ActionResult Vue()
        {
            return View();
        }
        // GET: Vue
        public ActionResult Component0()
        {
            return View();
        }
        public ActionResult Component1()
        {
            return View();
        }
    }
}