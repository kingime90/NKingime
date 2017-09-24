using System;
using System.Linq;

namespace NKingime.Core.Proxy
{
    /// <summary>
    /// 注册代理管理
    /// </summary>
    public static class ProxyManage
    {

        /// <summary>
        /// 注册
        /// </summary>
        public static void Register()
        {
            string fullName = typeof(IProxy).FullName;
            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).Where(type=> type.GetInterface(fullName) != null && !type.IsAbstract);
            var proxys = types.Select(s => Activator.CreateInstance(s) as IProxy).Where(p => p.Enabled).OrderBy(k => k.Priority).ToArray();
            foreach (var proxy in proxys)
            {
                proxy.Register();
            }
        }
    }
}
