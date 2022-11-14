using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadPoolDemo
{
    public class MyQueueUserWorkItemCallback: IThreadPoolWorkItem
	{
		private WaitCallback callback;

		private ExecutionContext context;

		private object state;


        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
