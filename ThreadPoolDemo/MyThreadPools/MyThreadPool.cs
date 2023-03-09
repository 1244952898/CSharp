using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadPoolDemo.MyThreadPools
{
    public delegate void MyWaitCallBack(object? state);
    internal class MyThreadPool
    {
        /// <summary>
        /// This method is called to request a new thread pool worker to handle pending work.
        /// </summary>
        internal static void RequestWorkerThread() => MyPortableThreadPool.ThreadPoolInstance.RequestWorker();


        public static void QueueUserWorkItem(MyWaitCallBack myWaitCallBack)
        {
            if (myWaitCallBack==null)
            {
                throw new Exception("myWaitCallBack is null");
            }

            //1. 初始化，获取执行上下文
            //EnsureInitialized();
            //ExecutionContext executionContext = ExecutionContext.Capture();
            //2.两种不同类型
            //object callback = ((executionContext == null || executionContext.IsDefault) ? ((QueueUserWorkItemCallbackBase)new QueueUserWorkItemCallbackDefaultContext(callBack, state)) : ((QueueUserWorkItemCallbackBase)new QueueUserWorkItemCallback(callBack, state, executionContext)));
            MyThreadPoolGlobals.workQueue.Enqueue(myWaitCallBack,true);
        }
    }
}
