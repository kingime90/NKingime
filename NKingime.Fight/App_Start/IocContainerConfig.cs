using Autofac.Integration.Mvc;
using NKingime.Core.Ioc;
using System.Web.Mvc;

namespace NKingime.Fight
{
    /// <summary>
    ///  IoC容器配置
    /// </summary>
    public class IocContainerConfig
    {

        /// <summary>
        /// 注册
        /// </summary>
        public static void Register()
        {
            IocContainerManage.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(IocContainerManage.IocContainer));
        }
    }
}