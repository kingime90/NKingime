using NKingime.Core.Extentsion;
using System.Configuration;

namespace NKingime.Core.Config
{
    /// <summary>
    /// 应用程序设置配置
    /// </summary>
    public static class AppSettingConfig
    {

        /// <summary>
        /// IoC MVC控制器程序集清单
        /// </summary>
        public static string IocMvcControllerAssemblys { get; private set; }

        /// <summary>
        /// IoC 依赖注入匹配的程序集正则表达式（不配置将加载所有的）
        /// </summary>
        public static string IocDependencyAssemblyPattern { get; private set; }

        /// <summary>
        /// 视图分页首页页码（默认第1页）
        /// </summary>
        public static int ViewPageNumber { get; private set; }

        /// <summary>
        /// 视图分页页大小（默认10条）
        /// </summary>
        public static int ViewPageSize { get; private set; }

        /// <summary>
        /// 加载
        /// </summary>
        static AppSettingConfig()
        {
            Load();
        }

        /// <summary>
        /// 加载
        /// </summary>
        public static void Load()
        {
            var appSettings = ConfigurationManager.AppSettings;
            IocMvcControllerAssemblys = appSettings["Ioc:MvcControllerAssemblys"];
            IocDependencyAssemblyPattern = appSettings["Ioc:DependencyAssemblyPattern"];
            ViewPageNumber = appSettings["View:PageNumber"].ToInt(1);
            ViewPageSize = appSettings["View:PageSize"].ToInt(10);

        }
    }
}
