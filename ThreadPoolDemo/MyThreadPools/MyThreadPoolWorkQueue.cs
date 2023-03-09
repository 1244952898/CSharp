using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using static ThreadPoolDemo.MyThreadPools.MyThreadPoolWorkQueue;

namespace ThreadPoolDemo.MyThreadPools
{
    internal class MyThreadPoolWorkQueue
    {
        // SOS's ThreadPool command depends on the following names
        internal readonly ConcurrentQueue<object> workItems = new ConcurrentQueue<object>();

        public void Enqueue(object callback, bool forceGlobal)
        {
            MyThreadPoolWorkQueueThreadLocals? tl;
            if (!forceGlobal && (tl = MyThreadPoolWorkQueueThreadLocals.threadLocals) != null)
            {
                tl.workStealingQueue.LocalPush(callback);
            }
            else
            {
                //internal readonly ConcurrentQueue<object> workItems = new ConcurrentQueue<object>();
                ConcurrentQueue<object> queue = (tl = MyThreadPoolWorkQueueThreadLocals.threadLocals) != null ? tl.assignedGlobalWorkItemQueue : workItems;
                queue.Enqueue(callback);
            }

            EnsureThreadRequested();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void EnsureThreadRequested()
        {
            // Only one thread is requested at a time to avoid over-parallelization
            //if (Interlocked.CompareExchange(ref _separated.hasOutstandingThreadRequest, 1, 0) == 0)
            //{
                MyThreadPool.RequestWorkerThread();
            //}
        }

        internal sealed class MyWorkStealingQueue
        {
            //其实这里有其他逻辑，简写这样
            public List<object> m_array = new List<object>();

            public void LocalPush(object obj)
            {
                m_array.Add(obj);
            }

            public object? LocalPop()
            {
                var obj = m_array.LastOrDefault();
                m_array.Remove(m_array.Count - 1);
                return obj;
            }
        }

        internal static class MyWorkStealingQueueList
        {
            //private static volatile MyWorkStealingQueue[] _queues = new MyWorkStealingQueue[0];
            //public static MyWorkStealingQueue[] Queues => _queues;
            private static List<MyWorkStealingQueue> _queues=new List<MyWorkStealingQueue>();
            public static void Add(MyWorkStealingQueue queue)
            {
                //其实这里有其他逻辑，简写这样
                _queues.Add(queue);
            }

            public static void Remove(MyWorkStealingQueue queue)
            {
                _queues.Remove(queue);
            }
        }
    }
}
