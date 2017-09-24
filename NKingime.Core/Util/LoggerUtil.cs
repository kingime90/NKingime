using Autofac;
using NKingime.Core.Ioc;
using NKingime.Core.Log;
using NKingime.Core.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKingime.Core.Util
{
    /// <summary>
    /// 日志记录器应用
    /// </summary>
    public static class LoggerUtil
    {

        /// <summary>
        /// 日志记录器接口
        /// </summary>
        private static readonly ILogger logger;

        static LoggerUtil()
        {
            logger = ProxyManage.GetInstance<ILogger>();
        }

        /// <summary>
        /// 记录调试
        /// </summary>
        /// <param name="message"></param>
        public static void Debug(string message)
        {
            logger.Debug(message);
        }

        /// <summary>
        /// 记录调试
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Debug(string message, Exception exception)
        {
            logger.Debug(message, exception);
        }

        /// <summary>
        /// 记录调试
        /// </summary>
        /// <param name="message"></param>
        public static void DebugAsync(string message)
        {
            Task.Run(() =>
            {
                Debug(message);
            });

        }

        /// <summary>
        /// 记录调试
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void DebugAsync(string message, Exception exception)
        {
            Task.Run(() =>
            {
                Debug(message, exception);
            });
        }

        /// <summary>
        /// 记录错误
        /// </summary>
        /// <param name="message"></param>
        public static void Error(string message)
        {
            logger.Error(message);
        }

        /// <summary>
        /// 记录错误
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Error(string message, Exception exception)
        {
            logger.Error(message, exception);
        }

        /// <summary>
        /// 记录错误
        /// </summary>
        /// <param name="message"></param>
        public static void ErrorAsync(string message)
        {
            Task.Run(() =>
            {
                Error(message);
            });
        }

        /// <summary>
        /// 记录错误
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void ErrorAsync(string message, Exception exception)
        {
            Task.Run(() =>
            {
                Error(message, exception);
            });
        }

        /// <summary>
        /// 记录信息
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string message)
        {
            logger.Info(message);
        }

        /// <summary>
        /// 记录信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Info(string message, Exception exception)
        {
            logger.Info(message, exception);
        }

        /// <summary>
        /// 记录信息
        /// </summary>
        /// <param name="message"></param>
        public static void InfoAsync(string message)
        {
            Task.Run(() =>
            {
                Info(message);
            });
        }

        /// <summary>
        /// 记录信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void InfoAsync(string message, Exception exception)
        {
            Task.Run(() =>
            {
                Info(message, exception);
            });
        }
    }
}
