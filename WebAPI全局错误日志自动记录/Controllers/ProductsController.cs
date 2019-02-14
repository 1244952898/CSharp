using System.Web.Http;
using WebAPI全局错误日志自动记录.Models;

namespace WebAPI全局错误日志自动记录.Controllers
{
    public class ProductsController : ApiController
    {
        [HttpGet]
        public Product FindProduct(string id)
        {
            return null;
        }
    }
}
