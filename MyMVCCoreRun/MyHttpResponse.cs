using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMVCCoreRun
{
    public abstract class MyHttpResponse
    {
        public abstract int StatusCode { get; set; }
        public abstract NameValueCollection Headers { get;}
        public abstract Stream Body { get;}
    }
}
