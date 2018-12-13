using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace 简单爬取商品信息
{
    public class UrlLoadHtmlHelper
    {
        public static string DownloadHtml(string url, Encoding encoding)
        {
            string html=String.Empty;
            try
            {
                HttpWebRequest request=WebRequest.CreateHttp(url) as HttpWebRequest;
                request.Timeout = 30 * 1000;
                request.UserAgent= "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.106 Safari/537.36";
                request.ContentType = "text/html; charset=utf-8";
                using (HttpWebResponse response =request.GetResponse() as HttpWebResponse)
                {
                    try
                    {
                        if (response.StatusCode==HttpStatusCode.OK)
                        {
                            StreamReader streamReader=new StreamReader(response.GetResponseStream(), encoding);
                            html = streamReader.ReadToEnd();//读取数据
                            streamReader.Close();
                        }
                       
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return html;
        }
    }
}
