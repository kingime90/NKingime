using NKingime.Core.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKingime.Core.Log
{
    /// <summary>
    /// 日志记录器接口
    /// </summary>
    public interface ILogger
    {

        /// <summary>
        /// 记录调试
        /// </summary>
        /// <param name="message"></param>
        void Debug(string message);

        /// <summary>
        /// 记录调试
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void Debug(string message, Exception exception);

        /// <summary>
        /// 记录错误
        /// </summary>
        /// <param name="message"></param>
        void Error(string message);

        /// <summary>
        /// 记录错误
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void Error(string message, Exception exception);

        /// <summary>
        /// 记录信息
        /// </summary>
        /// <param name="message"></param>
        void Info(string message);

        /// <summary>
        /// 记录信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void Info(string message, Exception exception);
    }
}
