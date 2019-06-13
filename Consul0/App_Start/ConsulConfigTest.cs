using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Consul;

namespace Consul0.App_Start
{
    public class ConsulConfigTest
    {
        public static async Task<string> ConsulTest()
        {
            try
            {
                using (var client = new ConsulClient(x=>x.Address=new Uri("http://120.27.213.67:8500")))
                {
                    var putPair = new KVPair("ConsulTest")
                    {
                        Value = Encoding.UTF8.GetBytes("Hello ConsulTest")
                    };
                    var putAttempt = await client.KV.Put(putPair);

                    if (putAttempt.Response)
                    {
                        var getPair = await client.KV.Get("ConsulTest");
                        return Encoding.UTF8.GetString(getPair.Response.Value, 0,
                            getPair.Response.Value.Length);
                    }
                    return "";

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }
}