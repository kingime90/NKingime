using NKingime.Core.Proxy;
using NKingime.Core.Util;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace NKingime.Fight
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ProxyManage.RegisterAll();
            RequiredConfig.Register();
            LoggerUtil.InfoAsync("站点启动中...");
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            IocContainerConfig.Register();
            LoggerUtil.InfoAsync("站点启动完成...");
        }
    }
}
