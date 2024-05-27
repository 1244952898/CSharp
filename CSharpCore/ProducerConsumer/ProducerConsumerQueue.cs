namespace CSharpCore.ProducerConsumer
{
    public class ProducerConsumerQueue : IDisposable
    {
        #region Fields
        private object _locker = new();
        private AutoResetEvent _autoResetEvent = new(false);
        private Queue<string> _quene = new Queue<string>();
        private Thread _worker;
        #endregion

        #region Constructors
        public ProducerConsumerQueue()
        {
            _worker = new Thread(Worker);
            _worker.Start();
        }
        #endregion

        #region Public Methods

        public void EnqueueTask(string task)
        {
            lock (_locker) 
                _quene.Enqueue(task);
            _autoResetEvent.Set();
        }

        /// <summary>
        /// 工作线程
        /// </summary>
        public void Worker()
        {
            while (true)
            {
                lock (_locker)
                {
                    string task = string.Empty;
                    if (_quene.Count > 0)
                    {
                        task = _quene.Dequeue();
                        if (string.IsNullOrWhiteSpace(task))
                        {
                            return;
                        }
                        Console.WriteLine("Performing task: " + task);
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        _autoResetEvent.WaitOne();
                    }
                }
            }
        }

        public void Dispose()
        {
            EnqueueTask(string.Empty);
            _worker.Join();
            _autoResetEvent.Close();
        }
        #endregion

    }
}
