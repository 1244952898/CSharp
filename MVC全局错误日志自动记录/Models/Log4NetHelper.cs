using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace Common
{
    public static class Log4NetHelper
    {
        private static ILog logger = null;
        private static object lockobj = new object();
        
        //写入错误log
        private static List<string> loggerLog = new List<string>();
        static Log4NetHelper()
        {
            if (logger == null)
            {
                lock (lockobj)
                {
                    if (logger == null)
                    {
                        XmlConfigurator.Configure();
                        logger = LogManager.GetLogger("log");
                    }
                }
            }
        }

        # region 定义了错误的五个级别
        /// <summary>
        /// 记录错误信息
        /// </summary>
        /// <param name="info"></param>
        public static void LogError(string message)
        {
            try
            {
                logger.Error(message);
            }
            catch (Exception e)
            {
                AddErrorLog("写入日志错误:" + message + ":\r\n" + e.ToString());
            }
        }
        /// <summary>
        /// 记录错误信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void LogError(string message, Exception ex)
        {
            try
            {
                logger.ErrorFormat("{0} {1}", message, ex.ToString());
            }
            catch (Exception e)
            {
                AddErrorLog("写入日志错误:" + message + ":\r\n" + e.ToString());
            }
        }

        /// <summary>
        /// 日志致命问题信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void LogFatal(string message)
        {
            try
            {
                logger.Fatal(message);
            }
            catch (Exception e)
            {
                AddErrorLog("写入日志错误:" + message + ":\r\n" + e.ToString());
            }
        }

        /// <summary>
        /// 日志致命问题信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void LogFatal(string message, Exception ex)
        {
            try
            {
                logger.FatalFormat("{0} {1}", message, ex.ToString());
            }
            catch (Exception e)
            {
                AddErrorLog("写入日志错误:" + message + ":\r\n" + e.ToString());
            }
        }
        /// <summary>
        /// 记录警告信息
        /// </summary>
        /// <param name="message"></param>
        public static void LogWarning(string message)
        {
            try
            {
                logger.Warn(message);
            }
            catch (Exception e)
            {
                AddErrorLog("写入日志错误:" + message + ":\r\n" + e.ToString());
            }
        }
        /// <summary>
        /// 记录一般信息
        /// </summary>
        /// <param name="message"></param>
        public static void LogInfo(string message)
        {
            try
            {
                logger.Info(System.Environment.NewLine + message);
            }
            catch (Exception e)
            {
                AddErrorLog("写入日志错误:" + message + ":\r\n" + e.ToString());
            }
        }

        public static void LogDebug(string message)
        {
            try
            {
                logger.Debug(message);
            }
            catch (Exception e)
            {
                AddErrorLog("写入日志错误:" + message + ":\r\n" + e.ToString());
            }
        }

        #endregion

        /// <summary>
        /// 添加错误信息
        /// </summary>
        /// <param name="eInfo">错误信息</param>
        private static void AddErrorLog(string eInfo)
        {
            if (loggerLog.Count > 50)
            {
                loggerLog.Clear();
            }
            loggerLog.Add(eInfo + " Time:" + System.DateTime.Now.ToString());
        }
    }
}
