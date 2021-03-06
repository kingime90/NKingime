﻿using Autofac;

namespace NKingime.Core.Ioc
{
    /// <summary>
    /// IoC容器管理
    /// </summary>
    public class IocContainerManage
    {

        private static IContainer _container;

        /// <summary>
        /// IoC容器
        /// </summary>
        public static IContainer Container
        {
            get
            {
                return _container;
            }
        }

        /// <summary>
        /// 构建
        /// </summary>
        public static void Build()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new DependencyModule());
            builder.RegisterModule(new MvcControllerModule());
            _container = builder.Build();
        }
    }
}
