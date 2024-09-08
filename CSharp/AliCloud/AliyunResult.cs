using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace CSharp.AliCloud
{
    public class AliyunResult<T>: AliyunBase
    {
        public T Data { get;set; }
    }
}