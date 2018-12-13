using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web;
using log4net;
using log4net.Config;

namespace MVC全局错误日志自动记录.Classes
{
    public sealed class FlashLogger
    {
        private static ILog _log = null;
        private static object lockobj = new object();
        /// <summary>
        /// 记录消息Queue
        /// </summary>
        private readonly ConcurrentQueue<FlashLogMessage> _que;

        /// <summary>
        /// 信号
        /// </summary>
        private readonly ManualResetEvent _mre;


        #region 实现单例

        private FlashLogger()
        {
            _que = new ConcurrentQueue<FlashLogMessage>();
            _mre = new ManualResetEvent(false);
            XmlConfigurator.Configure();
            //logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            if (_log == null)
            {
                lock (lockobj)
                {
                    if (_log == null)
                    {
                        XmlConfigurator.Configure();
                        _log = LogManager.GetLogger("log");
                    }
                }
            }
        }
        
        private static class FlashLoggerInstance
        {
            public static readonly FlashLogger Instance = new FlashLogger();
        }
       
        public static FlashLogger GetInstance()
        {
            return FlashLoggerInstance.Instance;
        }

        #endregion

        /// <summary>
        /// 另一个线程记录日志，只在程序初始化时调用一次
        /// </summary>
        public void Register()
        {
            Thread t = new Thread(new ThreadStart(WriteLog));
            t.IsBackground = false;
            t.Start();
        }

        /// <summary>
        /// 从队列中写日志至磁盘
        /// </summary>
        private void WriteLog()
        {
            while (true)
            {
                // 等待信号通知
                _mre.WaitOne();

                FlashLogMessage msg;
                // 判断是否有内容需要如磁盘 从列队中获取内容，并删除列队中的内容
                while (_que.Count > 0 && _que.TryDequeue(out msg))
                {
                    // 判断日志等级，然后写日志
                    switch (msg.Level)
                    {
                        case FlashLogLevel.Debug:
                            _log.Debug(msg.Message, msg.Exception);
                            break;
                        case FlashLogLevel.Info:
                            _log.Info(msg.Message, msg.Exception);
                            break;
                        case FlashLogLevel.Error:
                            _log.Error(msg.Message, msg.Exception);
                            break;
                        case FlashLogLevel.Warn:
                            _log.Warn(msg.Message, msg.Exception);
                            break;
                        case FlashLogLevel.Fatal:
                            _log.Fatal(msg.Message, msg.Exception);
                            break;
                    }
                }

                // 重新设置信号
                _mre.Reset();
                Thread.Sleep(1);
            }
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="message">日志文本</param>
        /// <param name="level">等级</param>
        /// <param name="ex">Exception</param>
        public void EnqueueMessage(string message, FlashLogLevel level, Exception ex = null)
        {
            if ((level == FlashLogLevel.Debug && _log.IsDebugEnabled)
                || (level == FlashLogLevel.Error && _log.IsErrorEnabled)
                || (level == FlashLogLevel.Fatal && _log.IsFatalEnabled)
                || (level == FlashLogLevel.Info && _log.IsInfoEnabled)
                || (level == FlashLogLevel.Warn && _log.IsWarnEnabled))
            {
                _que.Enqueue(new FlashLogMessage
                {
                    Message = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss,fff") + "]\r\n" + message,
                    Level = level,
                    Exception = ex
                });

                // 通知线程往磁盘中写日志
                _mre.Set();
            }
        }

        public static void Debug(string msg, Exception ex = null)
        {
            GetInstance().EnqueueMessage(msg, FlashLogLevel.Debug, ex);
        }

        public static void Error(string msg, Exception ex = null)
        {
            GetInstance().EnqueueMessage(msg, FlashLogLevel.Error, ex);
        }

        public static void Fatal(string msg, Exception ex = null)
        {
            GetInstance().EnqueueMessage(msg, FlashLogLevel.Fatal, ex);
        }

        public static void Info(string msg, Exception ex = null)
        {
            GetInstance().EnqueueMessage(msg, FlashLogLevel.Info, ex);
        }

        public static void Warn(string msg, Exception ex = null)
        {
            GetInstance().EnqueueMessage(msg, FlashLogLevel.Warn, ex);
        }

    }


    /// <summary>
    /// 日志等级
    /// </summary>
    public enum FlashLogLevel
    {
        Debug,
        Info,
        Error,
        Warn,
        Fatal
    }


    /// <summary>
    /// 日志内容
    /// </summary>
    public class FlashLogMessage
    {
        public string Message { get; set; }
        public FlashLogLevel Level { get; set; }
        public Exception Exception { get; set; }

    }

    //public sealed class FlashLogger1
    //{
    //    //单类日志初始化
    //    private FlashLogger1() { }
    //    private static object objLock = new object();
    //    private static readonly FlashLogger1 Instance;
    //    public static FlashLogger1 GetInstance()
    //    {
    //        if (Instance==null)
    //        {
    //            lock (objLock)
    //            {
    //                if (Instance == null)
    //                {
    //                    return new FlashLogger1();
    //                }
    //            }
    //        }
    //        return Instance;
    //    }

    //    public string Test()
    //    {
    //        return "a";
    //    }

    //}

}