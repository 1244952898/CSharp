using Microsoft.AspNetCore.Mvc;

namespace WebApplicationCore.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
