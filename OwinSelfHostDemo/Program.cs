using Microsoft.Owin.Hosting;
using OwinSelfHostDemo.OWIN;
using OwinSelfHostDemo.TopSelfclasses;
using OwinSelfHostDemo.TopShelfClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.HostConfigurators;

namespace OwinSelfHostDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //TopShelfConfigure.Config1();
            string baseAddress = "http://localhost:9000/";
            using (WebApp.Start<Startup>(baseAddress))
            {
                HttpClient httpClient = new HttpClient();
                var response = httpClient.GetAsync(baseAddress + "api/values").Result;
                Console.WriteLine(response);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                Console.ReadLine();
            }
        }
    }
}
