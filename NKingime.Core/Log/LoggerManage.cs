using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKingime.Core.Log
{
    /// <summary>
    /// 日志记录器管理
    /// </summary>
    public class LoggerManage
    {

        private static Func<ILogger> _logger;

        /// <summary>
        /// 日志记录器
        /// </summary>
        public static Func<ILogger> Logger
        {
            get
            {
                return _logger;
            }
        }

        /// <summary>
        /// 注册日志记录器
        /// </summary>
        /// <param name="logger"></param>
        public static void Register(Func<ILogger> logger)
        {
            _logger = logger;
        }
    }
}
