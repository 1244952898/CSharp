using EventBusCore.Models;
using EventBusCore.MyEventBus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EventBusCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            MyPublisher publisher = new MyPublisher();
            MyScbscriberA scbscriberA = new MyScbscriberA("scbscriberA");
            MyScbscriberB scbscriberB1 = new MyScbscriberB("scbscriberB1");
            MyScbscriberB scbscriberB2 = new MyScbscriberB("scbscriberB2");
            publisher.PublishTeatAEvent("test");
            publisher.PublishTeatBEvent(123);

            scbscriberB2.Unsubscribe_TeatBEvent();
            publisher.PublishTeatBEvent(12345);

            Console.ReadKey();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
