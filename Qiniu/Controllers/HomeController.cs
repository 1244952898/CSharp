using Qiniu.Storage;
using Qiniu.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Qiniu.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test()
        {
           var AccessKey = ConfigurationManager.AppSettings["AccessKey"];
           var SecretKey = ConfigurationManager.AppSettings["SecretKey"];
            Mac mac = new Mac(AccessKey, SecretKey);

            PutPolicy putPolicy = new PutPolicy();
            putPolicy.Scope = "sensori-south-bucket.s3-cn-south-1.qiniucs.com";
            string token = Auth.CreateUploadToken(mac, putPolicy.ToJsonString());

            return View();
        }
    }
}