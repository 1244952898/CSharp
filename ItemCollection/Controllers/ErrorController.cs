﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ItemCollection.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

        public ActionResult Error404(string aspxerrorpath)
        {
            ViewBag.aspxerrorpath = aspxerrorpath;
            return View();
        }
        public ActionResult Error500(string aspxerrorpath)
        {
            ViewBag.aspxerrorpath = aspxerrorpath;
            return View();
        }
    }
}