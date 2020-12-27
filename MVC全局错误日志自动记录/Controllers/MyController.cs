using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MVC全局错误日志自动记录.Controllers
{
    public class MyController : ApiController
    {
        public string Get()
        {
            var jsonTask = GetJsonAsync(new Uri("http://json.cn/"));
            return jsonTask.Result.ToString();
        }

        public static async Task<JObject> GetJsonAsync(Uri uri)
        {
            // (real-world code shouldn't use HttpClient in a using block; this is just example code)
            using (var client = new HttpClient())
            {
                var jsonString = await client.GetStringAsync(uri).ConfigureAwait(false);
                return JObject.Parse(jsonString);
            }
        }
    }
}
