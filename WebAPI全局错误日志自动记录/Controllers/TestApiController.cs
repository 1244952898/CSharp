using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI全局错误日志自动记录.Controllers
{
    public class TestApiController : ApiController
    {
        [HttpGet]
        public void Test()
        {
            int a = 50;
            long b = a / 0;
        }
    }
}
