using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CSharp
{
    public class ImgDemo
    {
        public static async Task AAsync()
        {
            try
            {
                var mageUrl = "http://img1.easypass.cn/das/carsource1/origin/4a2ccfdc-d298-4ac6-925a-2676ab30820e.png";
                using (HttpClient client = new HttpClient())
                {
                    //HttpResponseMessage res = await client.GetAsync(result.Data.ImageUrl);
                    //res.EnsureSuccessStatusCode();
                    //string responseBody = await res.Content.ReadAsStringAsync();

                    var arry = await client.GetStreamAsync(mageUrl);
 
                    //var st = DeCompress(memoryStream);
                    //var memoryStream = new MemoryStream(arry);
                    var img1 = System.Drawing.Image.FromStream(arry);
                    img1.Save("C:\\");   //保存
                }
                WebClient my = new WebClient();
                byte[] mybyte;
                mybyte = my.DownloadData(mageUrl);
                var ms = new MemoryStream(mybyte);
                var img = System.Drawing.Image.FromStream(ms);
                img.Save("C:\\");   //保存
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
    }
}
