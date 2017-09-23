using System;
using Autofac;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using NKingime.Core.Config;
using NKingime.Core.Extentsion;
using System.Text.RegularExpressions;
using NKingime.Core.Util;

namespace NKingime.Core.Ioc
{
    /// <summary>
    /// 依赖注入模块
    /// </summary>
    public class DependencyModule : Autofac.Module
    {

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            var dependencyAssemblyPrefix = AppSettingConfig.IocDependencyAssemblyPattern;
            //var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Cast<Assembly>();
            if (!dependencyAssemblyPrefix.IsNullOrWhiteSpace())
            {
                var regex = new Regex(dependencyAssemblyPrefix);
                assemblies = assemblies.Where(p => regex.IsMatch(p.FullName));
            }
            var dependencyType = typeof(IDependency);
            builder.RegisterAssemblyTypes(assemblies.ToArray()).Where(type => dependencyType.IsAssignableFrom(type) && !type.IsAbstract).AsImplementedInterfaces().InstancePerLifetimeScope();
            LoggerUtil.Info($"Ioc模块[{nameof(DependencyModule)}]注册完成");
        }
    }
}
