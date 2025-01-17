using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMVCCoreRun
{
    public abstract class MyHttpRequest
    {
        public abstract Uri Url { get; }
        public abstract NameValueCollection Headers { get; }
        public abstract Stream Body { get; }
    }
}
