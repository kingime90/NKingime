using System;
using System.Collections.Generic;

namespace NKingime.Core.Proxy
{
    /// <summary>
    /// 注册代理接口
    /// </summary>
    public interface IProxy
    {

        /// <summary>
        /// 优先级（升序）
        /// </summary>
        int Priority { get; }

        /// <summary>
        /// 存储和检索键
        /// </summary>
        string Key { get; }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="registerProxys">注册过的代理</param>
        void Register(Dictionary<string, Func<IProxyDependency>> registerProxys);
    }
}
