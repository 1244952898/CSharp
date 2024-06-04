using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCore
{
    interface Handler
    {
        public int DoStuff(string arg);
        public IAsyncResult BeginDoStuff(string arg, AsyncCallback? callback, object? state);
        public int EndDoStuff(IAsyncResult asyncResult);
    }
}
