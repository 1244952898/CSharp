using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 异步多线程学习
{
    public class ThreadExtesion
    {
        public void ThreadCallBack(ParameterizedThreadStart pts, Action action,params int[] ii) {
            ParameterizedThreadStart st = new ParameterizedThreadStart(x =>
            {
                pts.Invoke(x);
                action.Invoke();
            });
            Thread thread = new Thread(st);
            thread.Start(ii[0]);
        }
    }

    public static class StringUtilities
    {
        public static string FormatWith(this string format, IFormatProvider provider, object org0)
        {
            return format.FormatWith(provider, new object[] { org0 });
        }
        public static string FormatWith(this string format, IFormatProvider provider, object[] args)
        {
            return string.Format(provider, format, args);
        }
    }
}
