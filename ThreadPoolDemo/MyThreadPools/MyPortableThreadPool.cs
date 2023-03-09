using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Xml.Linq;

namespace ThreadPoolDemo.MyThreadPools
{
    internal class MyPortableThreadPool
    {
        // The singleton must be initialized after the static variables above, as the constructor may be dependent on them.
        // SOS's ThreadPool command depends on this name.
        public static readonly MyPortableThreadPool ThreadPoolInstance = new MyPortableThreadPool();
        private CacheLineSeparated _separated;

        //[StructLayout(LayoutKind.Explicit, Size = Internal.PaddingHelpers.CACHE_LINE_SIZE * 6)]
        private struct CacheLineSeparated
        {
            //[FieldOffset(Internal.PaddingHelpers.CACHE_LINE_SIZE * 1)]
            public ThreadCounts counts; // SOS's ThreadPool command depends on this name
        }
        internal void RequestWorker()
        {
            // The order of operations here is important. MaybeAddWorkingWorker() and EnsureRunning() use speculative checks to
            // do their work and the memory barrier from the interlocked operation is necessary in this case for correctness.
            //Interlocked.Increment(ref _separated.numRequestedWorkers);
            MyWorkerThread.MaybeAddWorkingWorker(this);
            //GateThread.EnsureRunning(this);
        }

        /// <summary>
        /// Tracks information on the number of threads we want/have in different states in our thread pool.
        /// </summary>
        private struct ThreadCounts : IEquatable<ThreadCounts>
        {
            private ulong _data; // SOS's ThreadPool command depends on this name
                                 // SOS's ThreadPool command depends on this layout
            private const byte NumProcessingWorkShift = 0;
            private const byte NumExistingThreadsShift = 16;
            private const byte NumThreadsGoalShift = 32;
            private short GetInt16Value(byte shift) => (short)(_data >> shift);
            private void SetInt16Value(short value, byte shift) =>
                _data = (_data & ~((ulong)ushort.MaxValue << shift)) | ((ulong)(ushort)value << shift);

            /// <summary>
            /// Number of threads processing work items.
            /// </summary>
            public short NumProcessingWork
            {
                get
                {
                    short value = GetInt16Value(NumProcessingWorkShift);
                    Debug.Assert(value >= 0);
                    return value;
                }
                set
                {
                    Debug.Assert(value >= 0);
                    SetInt16Value(Math.Max((short)0, value), NumProcessingWorkShift);
                }
            }

            /// <summary>
            /// Number of thread pool threads that currently exist.
            /// </summary>
            public short NumExistingThreads
            {
                get
                {
                    short value = GetInt16Value(NumExistingThreadsShift);
                    Debug.Assert(value >= 0);
                    return value;
                }
                set
                {
                    Debug.Assert(value >= 0);
                    SetInt16Value(Math.Max((short)0, value), NumExistingThreadsShift);
                }
            }

            /// <summary>
            /// Max possible thread pool threads we want to have.
            /// </summary>
            public short NumThreadsGoal
            {
                get
                {
                    short value = GetInt16Value(NumThreadsGoalShift);
                    Debug.Assert(value > 0);
                    return value;
                }
                set
                {
                    Debug.Assert(value > 0);
                    SetInt16Value(Math.Max((short)1, value), NumThreadsGoalShift);
                }
            }

            public ThreadCounts InterlockedCompareExchange(ThreadCounts newCounts, ThreadCounts oldCounts)
            {
                //#if DEBUG
                //                if (newCounts.NumThreadsGoal != oldCounts.NumThreadsGoal)
                //                {
                //                    ThreadPoolInstance._threadAdjustmentLock.VerifyIsLocked();
                //                }
                //#endif

                //return new ThreadCounts(Interlocked.CompareExchange(ref _data, newCounts._data, oldCounts._data));
                return new ThreadCounts();
            }


            private ThreadCounts(ulong data) => _data = data;
            public static bool operator ==(ThreadCounts lhs, ThreadCounts rhs) => lhs._data == rhs._data;
            public static bool operator !=(ThreadCounts lhs, ThreadCounts rhs) => lhs._data != rhs._data;

            public override bool Equals([NotNullWhen(true)] object? obj) => obj is ThreadCounts other && Equals(other);
            public bool Equals(ThreadCounts other) => _data == other._data;
            public override int GetHashCode() => (int)_data + (int)(_data >> 32);
        }


        internal class MyWorkerThread
        {
            internal static void MaybeAddWorkingWorker(MyPortableThreadPool threadPoolInstance)
            {
                ThreadCounts counts = threadPoolInstance._separated.counts;
                short numExistingThreads, numProcessingWork, newNumExistingThreads, newNumProcessingWork;
                while (true)
                {
                    numProcessingWork = counts.NumProcessingWork;
                    if (numProcessingWork >= counts.NumThreadsGoal)
                    {
                        return;
                    }

                    newNumProcessingWork = (short)(numProcessingWork + 1);
                    numExistingThreads = counts.NumExistingThreads;
                    newNumExistingThreads = Math.Max(numExistingThreads, newNumProcessingWork);

                    ThreadCounts newCounts = counts;
                    newCounts.NumProcessingWork = newNumProcessingWork;
                    newCounts.NumExistingThreads = newNumExistingThreads;

                    ThreadCounts oldCounts = threadPoolInstance._separated.counts.InterlockedCompareExchange(newCounts, counts);

                    if (oldCounts == counts)
                    {
                        break;
                    }

                    counts = oldCounts;
                }

                int toCreate = newNumExistingThreads - numExistingThreads;
                int toRelease = newNumProcessingWork - numProcessingWork;

                if (toRelease > 0)
                {
                    //s_semaphore.Release(toRelease);
                }

                while (toCreate > 0)
                {
                    CreateWorkerThread();
                    toCreate--;
                }
            }

            private static void CreateWorkerThread()
            {
                // Thread pool threads must start in the default execution context without transferring the context, so
                // using UnsafeStart() instead of Start()
                Thread workerThread = new Thread(s_workerThreadStart);
                //workerThread.IsThreadPoolThread = true;
                workerThread.IsBackground = true;
                // thread name will be set in thread proc
                //workerThread.UnsafeStart();
            }
        }

        private static readonly ThreadStart s_workerThreadStart = WorkerThreadStart;

        private static void WorkerThreadStart()
        {
            //Thread.CurrentThread.SetThreadPoolWorkerThreadName();

            //PortableThreadPool threadPoolInstance = ThreadPoolInstance;

            //if (NativeRuntimeEventSource.Log.IsEnabled())
            //{
            //    NativeRuntimeEventSource.Log.ThreadPoolWorkerThreadStart(
            //        (uint)threadPoolInstance._separated.counts.VolatileRead().NumExistingThreads);
            //}

            //LowLevelLock threadAdjustmentLock = threadPoolInstance._threadAdjustmentLock;
            //LowLevelLifoSemaphore semaphore = s_semaphore;

            //while (true)
            //{
            //    bool spinWait = true;
            //    while (semaphore.Wait(ThreadPoolThreadTimeoutMs, spinWait))
            //    {
            //        bool alreadyRemovedWorkingWorker = false;
            //        while (TakeActiveRequest(threadPoolInstance))
            //        {
            //            threadPoolInstance._separated.lastDequeueTime = Environment.TickCount;
            //            if (!ThreadPoolWorkQueue.Dispatch())
            //            {
            //                // ShouldStopProcessingWorkNow() caused the thread to stop processing work, and it would have
            //                // already removed this working worker in the counts. This typically happens when hill climbing
            //                // decreases the worker thread count goal.
            //                alreadyRemovedWorkingWorker = true;
            //                break;
            //            }

            //            if (threadPoolInstance._separated.numRequestedWorkers <= 0)
            //            {
            //                break;
            //            }

            //            // In highly bursty cases with short bursts of work, especially in the portable thread pool
            //            // implementation, worker threads are being released and entering Dispatch very quickly, not finding
            //            // much work in Dispatch, and soon afterwards going back to Dispatch, causing extra thrashing on
            //            // data and some interlocked operations, and similarly when the thread pool runs out of work. Since
            //            // there is a pending request for work, introduce a slight delay before serving the next request.
            //            // The spin-wait is mainly for when the sleep is not effective due to there being no other threads
            //            // to schedule.
            //            Thread.UninterruptibleSleep0();
            //            if (!Environment.IsSingleProcessor)
            //            {
            //                Thread.SpinWait(1);
            //            }
            //        }

            //        // Don't spin-wait on the semaphore next time if the thread was actively stopped from processing work,
            //        // as it's unlikely that the worker thread count goal would be increased again so soon afterwards that
            //        // the semaphore would be released within the spin-wait window
            //        spinWait = !alreadyRemovedWorkingWorker;

            //        if (!alreadyRemovedWorkingWorker)
            //        {
            //            // If we woke up but couldn't find a request, or ran out of work items to process, we need to update
            //            // the number of working workers to reflect that we are done working for now
            //            RemoveWorkingWorker(threadPoolInstance);
            //        }
            //    }

            //    // The thread cannot exit if it has IO pending, otherwise the IO may be canceled
            //    if (IsIOPending)
            //    {
            //        continue;
            //    }

            //    threadAdjustmentLock.Acquire();
            //    try
            //    {
            //        // At this point, the thread's wait timed out. We are shutting down this thread.
            //        // We are going to decrement the number of existing threads to no longer include this one
            //        // and then change the max number of threads in the thread pool to reflect that we don't need as many
            //        // as we had. Finally, we are going to tell hill climbing that we changed the max number of threads.
            //        ThreadCounts counts = threadPoolInstance._separated.counts;
            //        while (true)
            //        {
            //            // Since this thread is currently registered as an existing thread, if more work comes in meanwhile,
            //            // this thread would be expected to satisfy the new work. Ensure that NumExistingThreads is not
            //            // decreased below NumProcessingWork, as that would be indicative of such a case.
            //            if (counts.NumExistingThreads <= counts.NumProcessingWork)
            //            {
            //                // In this case, enough work came in that this thread should not time out and should go back to work.
            //                break;
            //            }

            //            ThreadCounts newCounts = counts;
            //            short newNumExistingThreads = --newCounts.NumExistingThreads;
            //            short newNumThreadsGoal =
            //                Math.Max(
            //                    threadPoolInstance.MinThreadsGoal,
            //                    Math.Min(newNumExistingThreads, counts.NumThreadsGoal));
            //            newCounts.NumThreadsGoal = newNumThreadsGoal;

            //            ThreadCounts oldCounts =
            //                threadPoolInstance._separated.counts.InterlockedCompareExchange(newCounts, counts);
            //            if (oldCounts == counts)
            //            {
            //                HillClimbing.ThreadPoolHillClimber.ForceChange(
            //                    newNumThreadsGoal,
            //                    HillClimbing.StateOrTransition.ThreadTimedOut);
            //                if (NativeRuntimeEventSource.Log.IsEnabled())
            //                {
            //                    NativeRuntimeEventSource.Log.ThreadPoolWorkerThreadStop((uint)newNumExistingThreads);
            //                }
            //                return;
            //            }

            //            counts = oldCounts;
            //        }
            //    }
            //    finally
            //    {
            //        threadAdjustmentLock.Release();
            //    }
            //}
        }
    }
}
