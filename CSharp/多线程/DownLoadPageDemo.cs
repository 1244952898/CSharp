using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.多线程
{
    internal class DownLoadPageDemo
    {
        public static async Task<string> DownLoadAsync(string[] urls)
        {
            if (urls == null)
            {
                return string.Empty;
            }

            var httpClient = new HttpClient();
            var resultsTask = urls.Select(url=>httpClient.GetStringAsync(url));
            Task<string>[] tasks= resultsTask.ToArray();
            var pageStr=await Task.WhenAll(tasks);
            //await Task.Yield();
            return string.Concat(pageStr);
        }
    }
}
