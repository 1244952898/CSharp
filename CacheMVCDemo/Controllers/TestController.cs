using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CacheMVCDemo.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult T()
        {
            DBHelper _dBHelper = new DBHelper();
            string msg;
            List<Person> ps = _dBHelper.GetData(out msg);
            ViewBag.msg = msg;
            return View(ps);
        }
    }
}