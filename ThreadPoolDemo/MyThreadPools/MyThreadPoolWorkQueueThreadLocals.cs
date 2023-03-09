using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace ThreadPoolDemo.MyThreadPools
{
    internal class MyThreadPoolWorkQueueThreadLocals
    {
        [ThreadStatic]
        public static MyThreadPoolWorkQueueThreadLocals threadLocals;
        public readonly MyThreadPoolWorkQueue.MyWorkStealingQueue workStealingQueue;
        public ConcurrentQueue<object> assignedGlobalWorkItemQueue;
        public readonly MyThreadPoolWorkQueue workQueue;

        public MyThreadPoolWorkQueueThreadLocals(MyThreadPoolWorkQueue tpq)
        {
            assignedGlobalWorkItemQueue = tpq.workItems;
            workQueue = tpq;
            workStealingQueue = new MyThreadPoolWorkQueue.MyWorkStealingQueue();
            MyThreadPoolWorkQueue.MyWorkStealingQueueList.Add(workStealingQueue);  
        }

        public void TransferLocalWork()
        {
            while (workStealingQueue.LocalPop() is object cb)
            {
                workQueue.Enqueue(cb, forceGlobal: true);
            }
        }

        ~MyThreadPoolWorkQueueThreadLocals()
        {
            if (null != workStealingQueue)
            {
                TransferLocalWork();
                MyThreadPoolWorkQueue.MyWorkStealingQueueList.Remove(workStealingQueue);
            }
        }
    }
}
