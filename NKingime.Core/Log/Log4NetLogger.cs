using log4net;
using System;
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Config/log4net.config", ConfigFileExtension = "config", Watch = true)]

namespace NKingime.Core.Log
{
    /// <summary>
    /// log4net日志记录器
    /// </summary>
    public class Log4NetLogger : ILogger
    {
        private static readonly ILog logger;

        static Log4NetLogger()
        {
            logger = LogManager.GetLogger("Infrastructure");
        }

        /// <summary>
        /// 记录调试
        /// </summary>
        /// <param name="message"></param>
        public void Debug(string message)
        {
            logger.Debug(message);
        }

        /// <summary>
        /// 记录调试
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Debug(string message, Exception exception)
        {
            logger.Debug(message, exception);
        }

        /// <summary>
        /// 记录错误
        /// </summary>
        /// <param name="message"></param>
        public void Error(string message)
        {
            logger.Error(message);
        }

        /// <summary>
        /// 记录错误
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Error(string message, Exception exception)
        {
            logger.Error(message, exception);
        }

        /// <summary>
        /// 记录信息
        /// </summary>
        /// <param name="message"></param>
        public void Info(string message)
        {
            logger.Info(message);
        }

        /// <summary>
        /// 记录信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public void Info(string message, Exception exception)
        {
            logger.Info(message, exception);
        }
    }
}
