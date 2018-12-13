using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace 简单爬取商品信息
{
    class Program
    {
        static void Main(string[] args)
        {
            string html = HttpHelper.DownloadUrl(@"https://list.jd.com/list.html?cat=1620,11158,11964");
            HtmlDocument productDoc = new HtmlDocument();
            productDoc.LoadHtml(html);
            HtmlNode pageNode = productDoc.DocumentNode.SelectSingleNode(@"//*[@id='J_topPage']/span/i");
            if (pageNode != null)
            {

                int pageNum = Convert.ToInt32(pageNode.InnerText);
                for (int i = 1; i < pageNum + 1; i++)
                {
                    //string pageUrl = string.Format("{0}&page={1}", category.Url, i).Replace("&page=1&", string.Format("&page={0}&", i));
                    try
                    {
                        //List<ProductInfo> proDuctInfo = GetPageProduct(pageUrl);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

        }
    }
}
