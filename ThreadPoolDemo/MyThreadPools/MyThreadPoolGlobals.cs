using System;
using System.Collections.Generic;
using System.Text;

namespace ThreadPoolDemo.MyThreadPools
{
    internal class MyThreadPoolGlobals
    {
        public static readonly MyThreadPoolWorkQueue workQueue = new MyThreadPoolWorkQueue();
    }
}
