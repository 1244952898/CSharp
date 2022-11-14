using System;
using System.Collections.Generic;
using System.Text;

namespace ThreadPoolDemo
{
    [Serializable]
    public enum StackCrawlMark
    {
        LookForMe,
        LookForMyCaller,
        LookForMyCallersCaller,
        LookForThread
    }
}
