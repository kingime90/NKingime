using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NKingime.Core.Ioc
{
    /// <summary>
    /// 
    /// </summary>
    public class ControllerModule : Autofac.Module
    {

        /// <summary>
        /// 
        /// </summary>
        public const string AssemblyTypesKey = "Controller.Types";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            var assemblyTypes = ConfigurationManager.AppSettings[AssemblyTypesKey];
            var assemblies = assemblyTypes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(p => Assembly.Load(p)).ToArray();
            builder.RegisterControllers(assemblies);
        }
    }
}
