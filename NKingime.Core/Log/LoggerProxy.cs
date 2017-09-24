using NKingime.Core.Proxy;
using System;
using System.Collections.Generic;

namespace NKingime.Core.Log
{
    /// <summary>
    /// 日志记录器注册
    /// </summary>
    public class LoggerProxy : ProxyBase<ILogger>
    {

        /// <summary>
        /// 优先级（升序）
        /// </summary>
        public override int Priority
        {
            get
            {
                return 1;
            }
        }

        /// <summary>
        /// 代理
        /// </summary>
        /// <returns></returns>
        public override Func<IProxyDependency> Proxy()
        {
            return ProxyInstance;
        }

        /// <summary>
        /// 注册日志记录器代理实例
        /// </summary>
        /// <returns></returns>
        public IProxyDependency ProxyInstance()
        {
            return new Log4NetLogger();
        }
    }
}
