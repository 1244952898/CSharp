using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace coreDemo1.Controllers
{
    public class ESController : Controller
    {
        public IActionResult Let()
        {
            for (int i = 0; i < 10; i++)
            {
            }
            return View();
        }
    }
}