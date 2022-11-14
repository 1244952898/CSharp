using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace ThreadPoolDemo
{
	internal static class MyThreadPoolGlobals
	{
		public static uint tpQuantum;

		public static int processorCount;

		public static bool tpHosted;

		public static volatile bool vmTpInitialized;

		public static bool enableWorkerTracking;

		[SecurityCritical]
		public static ThreadPoolWorkQueue workQueue;

		[SecuritySafeCritical]
		static MyThreadPoolGlobals()
		{
			tpQuantum = 30u;
			processorCount = Environment.ProcessorCount;
			tpHosted = MyThreadPool.IsThreadPoolHosted();
			workQueue = new ThreadPoolWorkQueue();
		}
	}
}
