using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ItemCollection.Controllers
{
    public class PostMessageController : Controller
    {
       /// <summary>
       /// 
       /// </summary>
       /// <returns></returns>
        public ActionResult PostMessageA()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult PostMessageB()
        {
            return View();
        }
    }
}