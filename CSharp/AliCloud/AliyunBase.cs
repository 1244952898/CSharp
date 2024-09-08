using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharp.AliCloud
{
    public class AliyunBase
    {
        public int Code { get; set; }
        public string Msg { get; set; }
    }

    public class AliyunResultModel<T> : AliyunBase where T : class
    {
        public T Data { get; set; }
    }
}