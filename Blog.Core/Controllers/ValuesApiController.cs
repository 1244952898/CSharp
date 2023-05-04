using Blog.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Blog.Core.Controllers
{
    /// <summary>
    /// 注释Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesApiController : ControllerBase
    {
        /// <summary>
        /// 注释Action-Get
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns>id列表</returns>
        [HttpGet("get")]
        [ApiExplorerSettings(IgnoreApi =true)]
        public IEnumerable<string> Get(string id, SwaggerModel m)
        {
            return new string[] {"a","b","c",id,m.Name };
        }

        /// <summary>
        /// 注释Action-SwaggerModel
        /// </summary>
        /// <param name="model">SwaggerModel</param>
        /// <returns>s</returns>
        [HttpPost]
        public string Post(SwaggerModel model)
        {
            return model.Name;
        }
    }
}
