using Autofac;
using Autofac.Integration.Mvc;
using NKingime.Core.Config;
using NKingime.Core.Extentsion;
using NKingime.Core.Util;
using System;
using System.Linq;
using System.Reflection;

namespace NKingime.Core.Ioc
{
    /// <summary>
    /// Nvc控制器注入模块
    /// </summary>
    public class MvcControllerModule : Autofac.Module
    {

        /// <summary>
        /// 加载模块
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            var mvcControllerAssemblys = AppSettingConfig.IocMvcControllerAssemblys;
            if (!mvcControllerAssemblys.IsNullOrWhiteSpace())
            {
                var assemblies = mvcControllerAssemblys.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(p => Assembly.Load(p)).ToArray();
                builder.RegisterControllers(assemblies);
            }
            LoggerUtil.InfoAsync($"Ioc模块[{typeof(MvcControllerModule).FullName}]注册完成");
        }
    }
}
