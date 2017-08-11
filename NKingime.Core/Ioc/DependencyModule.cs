using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace NKingime.Core.Ioc
{
    /// <summary>
    /// 依赖注入模块
    /// </summary>
    public class DependencyModule : Autofac.Module
    {

        /// <summary>
        /// 依赖注入程序集类型键
        /// </summary>
        public const string AssemblyTypesKey = "DependencyModule.Types";

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            var assemblyTypes = ConfigurationManager.AppSettings[AssemblyTypesKey];
            var dependencyType = typeof(IDependency);
            var assemblies = assemblyTypes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(p => Assembly.Load(p)).ToArray();
            builder.RegisterAssemblyTypes(assemblies).Where(type => dependencyType.IsAssignableFrom(type) && !type.IsAbstract).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
