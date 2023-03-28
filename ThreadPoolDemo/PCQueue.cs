using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ThreadPoolDemo
{
    internal class PCQueue
    {
        private readonly object _locker=new object();
        private Thread[] _threads;
        private Queue<Action> _itemQ = new Queue<Action>();
        public PCQueue(int count)
        {
            _threads=new Thread[count];
            for (int i = 0; i < count; i++)
            {
                (_threads[i] = new Thread(Consume)).Start();

            }
        }

        public void EnqueueItem(Action item)
        {
            lock (_locker)
            {
                _itemQ.Enqueue(item);
                Monitor.Pulse(_locker);
            }
        }

        public void Shutdown(bool waitForWorkers) 
        {
            foreach (var t in _threads)
            {
                EnqueueItem(null);

            }

            if (waitForWorkers)
            {
                foreach (var t in _threads)
                {
                    t.Join();
                }
            }
        }

        public void Consume()
        {
            while (true)
            {
                Action action= null;
                lock (_locker)
                {
                    while (_itemQ.Count==0)
                    {
                        Monitor.Wait(_locker);
                    }
                    action = _itemQ.Dequeue();
                }
                if (action==null)
                {
                    return;
                }
                action();
            }
        }
    }
}
