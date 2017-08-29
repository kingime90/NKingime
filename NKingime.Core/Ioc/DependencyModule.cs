using Autofac;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using NKingime.Core.Config;
using NKingime.Core.Extentsion;

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
            var dependencyAssemblyPrefix = AppSettingConfig.IocDependencyAssemblyPrefix;
            var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>();
            if (!dependencyAssemblyPrefix.IsNullOrWhiteSpace())
            {
                assemblies = assemblies.Where(p => p.FullName.StartsWith(dependencyAssemblyPrefix));
            }
            var dependencyType = typeof(IDependency);
            builder.RegisterAssemblyTypes(assemblies.ToArray()).Where(type => dependencyType.IsAssignableFrom(type) && !type.IsAbstract).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
