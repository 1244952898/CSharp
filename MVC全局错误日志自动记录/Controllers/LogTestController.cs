using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC全局错误日志自动记录.Classes;

namespace MVC全局错误日志自动记录.Controllers
{
    public class LogTestController : Controller
    {
        // GET: LogTest
        public ActionResult T()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 100000; i++)
            {
                FlashLogger.Debug("Debug", new Exception(string.Concat("testexception",i)));
            }
            stopwatch.Stop();
            double milliseconds = stopwatch.Elapsed.TotalMilliseconds;
            ViewBag.milliseconds = milliseconds;
            return View();
        }
    }
}