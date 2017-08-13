using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKingime.Core.Ioc
{
    /// <summary>
    /// IoC容器管理
    /// </summary>
    public class IocContainerManage
    {

        private static IContainer _iocContainer;

        /// <summary>
        /// IoC容器
        /// </summary>
        public static IContainer IocContainer
        {
            get
            {
                return _iocContainer;
            }
        }

        /// <summary>
        /// 构建
        /// </summary>
        public static void Build()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new DependencyModule());
            builder.RegisterModule(new ControllerModule());
            _iocContainer = builder.Build();
        }
    }
}
