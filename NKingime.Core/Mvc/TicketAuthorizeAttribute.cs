using NKingime.Core.Define;
using NKingime.Core.Entity;
using NKingime.Core.Extentsion;
using NKingime.Core.Util;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NKingime.Core.Mvc
{
    /// <summary>
    /// 票证授权过滤器
    /// </summary>
    public class TicketAuthorizeAttribute : AuthorizeAttribute
    {

        /// <summary>
        /// 重写时，提供一个入口点用于进行自定义授权检查
        /// </summary>
        /// <param name="httpContext">HTTP 上下文，它封装有关单个 HTTP 请求的所有 HTTP 特定的信息</param>
        /// <returns></returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authCookie = httpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null)
            {
                return false;
            }
            //
            if (string.IsNullOrWhiteSpace(authCookie.Value))
            {
                return false;
            }
            //
            FormsAuthenticationTicket authTicket;
            try
            {
                authTicket = FormsAuthentication.Decrypt(authCookie.Value);//解密
            }
            catch
            {
                return false;
            }
            //
            if (authTicket == null || string.IsNullOrWhiteSpace(authTicket.UserData))
            {
                return false;
            }
            //
            UserData userData;
            try
            {
                userData = JsonUtil.Deserialize<UserData>(authTicket.UserData.FromBase64());
            }
            catch
            {
                return false;
            }
            //
            if (userData == null)
            {
                return false;
            }
            //
            httpContext.Items.Add(GlobalKeys.TicketUserDataKey, userData);
            return true;
        }

        /// <summary>
        /// 处理未能授权的 HTTP 请求
        /// </summary>
        /// <param name="filterContext">封装有关使用 System.Web.Mvc.AuthorizeAttribute 的信息。filterContext 对象包括控制器、HTTP 上下文、请求上下文、操作结果和路由数据</param>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            string redirectUrl = filterContext.HttpContext.Request.Url.PathAndQuery;
            if (redirectUrl != "/")
            {
                redirectUrl = $"{FormsAuthentication.LoginUrl}?returnUrl={HttpUtility.UrlEncode(redirectUrl)}";
            }
            else
            {
                redirectUrl = FormsAuthentication.LoginUrl;
            }
            filterContext.Result = new RedirectResult(redirectUrl);
        }
    }
}
