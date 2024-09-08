
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CSharp.AliCloud
{
    public class AliyunConfig
    {
        #region Fields
        public string Url { get; set; }
        public string Bucket { get; set; }
        public string AccessKeyId { get; set; }
        public string AccessKeySecret { get; set; }
        public ClientConfiguration ClientConfig { get; set; }

        #endregion

        #region Constructors

        public AliyunConfig()
        {
            Url = ConfigurationManager.AppSettings["ali_cloud_url"].ToString();
            Bucket = ConfigurationManager.AppSettings["ali_cloud_bucket"].ToString();
            AccessKeyId = ConfigurationManager.AppSettings["ali_cloud_accessKeyId"].ToString();
            AccessKeySecret = ConfigurationManager.AppSettings["ali_cloud_accessKeySecret"].ToString();

            ClientConfig = new ClientConfiguration
            {
                ConnectionLimit = 512,
                MaxErrorRetry = 3,
                ConnectionTimeout = 1000 * 60 * 60,
                EnalbeMD5Check = true,
            };

        }

        #endregion

        #region structs
        public struct ClientConfiguration
        {
            /// <summary>
            /// // 设置最大并发连接数
            /// </summary>
            public int ConnectionLimit { get; set; }

            /// <summary>
            /// 设置请求失败后最大的重试次数
            /// </summary>
            public int MaxErrorRetry { get; set; }

            /// <summary>
            ///  设置连接超时时间(毫秒)
            /// </summary>
            public int ConnectionTimeout { get; set; }

            /// <summary>
            /// 开启MD5校验
            /// </summary>
            public bool EnalbeMD5Check { get; set; }
        }
        #endregion
    }
}