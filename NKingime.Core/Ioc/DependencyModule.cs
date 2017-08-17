using Autofac;
using System;
using System.Linq;
using System.Reflection;
using System.Configuration;
using System.Web.Compilation;

namespace NKingime.Core.Ioc
{
    /// <summary>
    /// 依赖注入模块
    /// </summary>
    public class DependencyModule : Autofac.Module
    {

        /// <summary>
        /// 依赖注入程序集前缀键
        /// </summary>
        public const string DependencyAssemblyPrefixKey = "NKingime.";

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            //var assemblyTypes = ConfigurationManager.AppSettings["DependencyModule.Types"];
            var assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>().Where(p => p.FullName.StartsWith(DependencyAssemblyPrefixKey)).ToArray();
            var dependencyType = typeof(IDependency);
            //var assemblies = assemblyTypes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(p => Assembly.Load(p)).ToArray();
            builder.RegisterAssemblyTypes(assemblies).Where(type => dependencyType.IsAssignableFrom(type) && !type.IsAbstract).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
