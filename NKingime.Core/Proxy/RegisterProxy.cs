using NKingime.Core.Log;
using NKingime.Core.Util;
using System;
using System.Collections.Generic;

namespace NKingime.Core.Proxy
{

    /// <summary>
    /// 注册代理泛型基类
    /// </summary>
    /// <typeparam name="T">代理接口类型</typeparam>
    public abstract class RegisterProxy<T> : RegisterProxy, IProxy where T : IProxyDependency
    {

        /// <summary>
        /// 
        /// </summary>
        protected RegisterProxy()
        {

        }

        /// <summary>
        /// 是否启用（默认true启用）
        /// </summary>
        public virtual bool Enabled
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// 存储和检索键
        /// </summary>
        public string Key
        {
            get
            {
                return GetKey<T>();
            }
        }

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
        /// 注册
        /// </summary>
        public virtual void Register()
        {
            var proxy = Proxy();
            if (proxy == null)
                return;
            //
            SetProxy(Key, proxy);
            if (Exists<ILogger>())
            {
                LoggerUtil.InfoAsync($"接口代理[{typeof(T).FullName}]注册完成");
            }
        }

        /// <summary>
        /// 代理
        /// </summary>
        /// <returns></returns>
        public virtual Func<IProxyDependency> Proxy()
        {
            return default(Func<IProxyDependency>);
        }
    }

    /// <summary>
    /// 注册代理基类
    /// </summary>
    public class RegisterProxy
    {

        /// <summary>
        /// 注册代理字典
        /// </summary>

        private static Dictionary<string, Func<IProxyDependency>> _registerProxys;

        /// <summary>
        /// 
        /// </summary>
        static RegisterProxy()
        {
            _registerProxys = new Dictionary<string, Func<IProxyDependency>>();
        }

        /// <summary>
        /// 获取存储和检索键
        /// </summary>
        /// <typeparam name="T">代理接口类型</typeparam>
        /// <returns></returns>
        public static string GetKey<T>() where T : IProxyDependency
        {
            return typeof(T).FullName;
        }

        /// <summary>
        /// 设置代理
        /// </summary>
        /// <typeparam name="T">代理接口类型</typeparam>
        /// <param name="registerProxy">注册代理</param>

        public static void SetProxy<T>(Func<IProxyDependency> registerProxy) where T : IProxyDependency
        {
            string key = GetKey<T>();
            SetProxy(key, registerProxy);
        }

        /// <summary>
        /// 设置代理
        /// </summary>
        /// <typeparam name="T">代理接口类型</typeparam>
        /// <param name="key">存储和检索键</param>
        /// <param name="registerProxy">注册代理</param>
        protected static void SetProxy(string key, Func<IProxyDependency> registerProxy)
        {
            if (!_registerProxys.ContainsKey(key))
            {
                _registerProxys.Add(key, registerProxy);
            }
            else
            {
                _registerProxys[key] = registerProxy;
            }
        }

        /// <summary>
        /// 获取代理
        /// </summary>
        /// <param name="key">存储和检索键</param>
        /// <param name="checkNull">是否检查Null</param>
        /// <returns></returns>
        public static Func<IProxyDependency> GetProxy<T>(bool checkNull = true) where T : IProxyDependency
        {
            string key = GetKey<T>();
            var proxy = _registerProxys[key];
            if (checkNull && proxy == null)
            {

            }
            return proxy;
        }

        /// <summary>
        /// 获取实例
        /// </summary>
        /// <typeparam name="T">代理接口类型</typeparam>
        /// <param name="key">存储和检索键</param>
        /// <param name="registerProxy">注册代理</param>
        /// <returns></returns>
        public static T GetInstance<T>(bool checkNull = true) where T : IProxyDependency
        {
            var proxy = GetProxy<T>(checkNull);
            var instance = proxy();
            if (checkNull && instance == null)
            {

            }
            return (T)instance;
        }

        /// <summary>
        /// 存在注册代理接口
        /// </summary>
        /// <typeparam name="T">代理接口类型</typeparam>
        /// <returns></returns>
        public static bool Exists<T>() where T : IProxyDependency
        {
            string key = GetKey<T>();
            return Exists(key);
        }

        /// <summary>
        /// 存在注册代理接口
        /// </summary>
        /// <param name="key">存储和检索键</param>
        /// <returns></returns>
        public static bool Exists(string key)
        {
            return _registerProxys.ContainsKey(key);
        }
    }
}