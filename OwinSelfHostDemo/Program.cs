﻿using Microsoft.Owin.Hosting;
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
            #region Web API 代码的自定义主机
            //var baseAddress = new Uri("http://localhost:5000");

            //var config = new HttpSelfHostConfiguration(baseAddress);
            //config.Routes.MapHttpRoute("default", "{controller}");

            //using (var svr = new HttpSelfHostServer(config))
            //{
            //    svr.OpenAsync().Wait();
            //    Console.WriteLine("Press Enter to quit.");
            //    Console.ReadLine();
            //}
            #endregion
        }
    }
}
