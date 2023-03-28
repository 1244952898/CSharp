using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadPoolDemo
{
    //[Synchronization]
    internal class ProducerConsumerQueue : IDisposable
    {
        EventWaitHandle _wh=new AutoResetEvent(false);
        Thread _worker;
        readonly object _locker=new object();
        Queue<string> _tasks= new Queue<string>();

        public ProducerConsumerQueue()
        {
            _worker = new Thread(Work);
            _worker.Start();
        }

        public void EnqueueTask(string t)
        {
            lock (_locker)
            {
                _tasks.Enqueue(t);
                _wh.Set();
            }
        }

        public void Work() 
        { 
        
        }

        public void Dispose()
        {
            _tasks.Enqueue(null);
            _wh.Close();
            _worker.Join();
        }
    }
}
