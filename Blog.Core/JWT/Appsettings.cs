using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Core.JWT
{
    public class Appsettings
    {
        static IConfiguration Configuration { get; set; }
        static string basePath { get; set; }
        /// <summary>
        /// appsettings.json操作类
        /// </summary>
        /// <param name="basePath"></param>
        public Appsettings(string basePath) 
        {
            //var path = $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json";
            var path = "appsettings.json";
            Configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .Add(new JsonConfigurationSource
                {
                    Path = path,
                    Optional = false,
                    ReloadOnChange = true,
                })
                .Build();
        }

        public Appsettings(IConfiguration configuration)
        {
            Configuration=configuration;
        }

        /// <summary>
        /// 封装要操作的字符
        /// </summary>
        /// <param name="sections">节点配置</param>
        /// <returns></returns>
        public static string app(params string[] sections)
        {
            try
            {
                if (sections.Any())
                {
                    return Configuration[string.Join(":", sections)];
                }
                
            }
            catch (Exception e)
            {
                throw;
            }
            return default;
        }

        /// <summary>
        /// 递归获取配置信息数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sections"></param>
        /// <returns></returns>
        public static List<T> app<T>(params string[] sections)
        {
            List<T> list = new List<T>();
            // 引用 Microsoft.Extensions.Configuration.Binder 包
            Configuration.Bind(string.Join(":", sections), list);
            return list;
        }
    }
}
