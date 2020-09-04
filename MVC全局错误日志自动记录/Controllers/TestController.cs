using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Common;
using Newtonsoft.Json.Linq;

namespace MVC全局错误日志自动记录.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Test()
        {
            Log4NetHelper.LogDebug("LogDebug");
            Log4NetHelper.LogError("LogError");
            Log4NetHelper.LogFatal("LogFatal");
            Log4NetHelper.LogInfo("LogInfo");
            Log4NetHelper.LogWarning("LogWarning");
            
            return View();
        }
        public ActionResult T()
        {
            List<string> strList=null;
            int count= strList.Count;
            return View();
        }

  
    }
}