using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading;

namespace ThreadPoolDemo
{
    public static class MyThreadPool
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        [SecurityCritical]
        internal static extern bool IsThreadPoolHosted();


        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool QueueUserWorkItem(WaitCallback callback,object state)
        {
            StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
            return QueueUserWorkItemHelper(callback, state,ref stackCrawlMark, true);
        }

        public static bool QueueUserWorkItemHelper(WaitCallback callback, object state,ref StackCrawlMark stackCrawlMark, bool compressStack)
        {
            bool result = false;
            if (callback!=null)
            {
                EnsureVMInitialized();
                try
                {

                }
                finally
                {
                    //MyQueueUserWorkItemCallback
                }
                return result;
            }

            throw new ArgumentNullException("WaitCallback");
        }

        [SecurityCritical]
        public static void EnsureVMInitialized()
        {
            if (!MyThreadPoolGlobals.vmTpInitialized)
            {
                //InitializeVMTp(ref ThreadPoolGlobals.enableWorkerTracking);
                MyThreadPoolGlobals.vmTpInitialized = true;
            }
        }
    }
}
