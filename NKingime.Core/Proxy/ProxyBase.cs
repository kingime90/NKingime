using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKingime.Core.Proxy
{

    /// <summary>
    /// 注册代理接口基类
    /// </summary>
    public abstract class ProxyBase<T> : IProxy where T : IProxyDependency
    {

        /// <summary>
        /// 优先级（升序，默认32位有符号整数最大值）
        /// </summary>
        public virtual int Priority
        {
            get
            {
                return int.MaxValue;
            }
        }

        /// <summary>
        /// 存储和检索键
        /// </summary>
        public string Key
        {
            get
            {
                return GetKey();
            }
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="registerProxys">注册过的代理</param>
        public virtual void Register(Dictionary<string, Func<IProxyDependency>> registerProxys)
        {
            var proxy = Proxy();
            if (proxy == null)
                return;
            //
            registerProxys.Add(Key, proxy);
        }

        /// <summary>
        /// 代理
        /// </summary>
        /// <returns></returns>
        public virtual Func<IProxyDependency> Proxy()
        {
            return default(Func<IProxyDependency>);
        }

        /// <summary>
        /// 获取存储和检索键
        /// </summary>
        /// <typeparam name="RegisterProxy"></typeparam>
        /// <returns></returns>
        public static string GetKey()
        {
            return typeof(T).FullName;
        }
    }
}