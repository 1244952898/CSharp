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

        [OutputCache(Duration =20)]
        public ActionResult ExampleCache()
        {
            var timeStr = DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分ss秒");
            ViewBag.timeStr = timeStr;
            return View();
        }

        [OutputCache(Duration = 2)]
        public ActionResult ExampleCache1()

        {
            var timeStr = DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分ss秒");
            ViewBag.timeStr = timeStr;
            return View();
        }
    }
}