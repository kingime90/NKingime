using System;
using System.Collections.Generic;
using System.Linq;

namespace NKingime.Core.Proxy
{
    /// <summary>
    /// 注册代理管理
    /// </summary>
    public class ProxyManage
    {

        /// <summary>
        /// 
        /// </summary>

        private static Dictionary<string, Func<IProxyDependency>> _registerProxys;

        /// <summary>
        /// 
        /// </summary>
        static ProxyManage()
        {
            _registerProxys = new Dictionary<string, Func<IProxyDependency>>();
        }

        /// <summary>
        /// 注册所有
        /// </summary>
        public static void RegisterAll()
        {
            string fullName = typeof(IProxy).FullName;
            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes());
            IProxy register;
            foreach (var type in types)
            {
                if (type.GetInterface(fullName) == null || type.IsAbstract)
                    continue;
                //
                register = Activator.CreateInstance(type) as IProxy;
                register.Register(_registerProxys);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="checkNull"></param>
        /// <returns></returns>
        public static Func<IProxyDependency> GetProxy<T>(bool checkNull = true) where T : IProxyDependency
        {
            string key = ProxyBase<T>.GetKey();
            var proxy = _registerProxys[key];
            if (checkNull && proxy == null)
            {

            }
            return proxy;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="checkNull"></param>
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
    }
}
