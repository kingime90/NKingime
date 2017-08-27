using NKingime.Core.Define;
using NKingime.Core.Entity;
using System.Web.Mvc;

namespace NKingime.Core.Mvc
{
    /// <summary>
    /// 令牌控制器基类
    /// </summary>
    public abstract class TicketController : Controller
    {

        /// <summary>
        /// 
        /// </summary>
        public TicketController() : base()
        {

        }

        private UserData userData;

        /// <summary>
        /// 用户数据
        /// </summary>
        public UserData UserData
        {
            get
            {
                if (userData == null)
                {
                    userData = HttpContext.Items[GlobalKeys.TicketUserDataKey] as UserData;
                }
                //
                return userData;
            }
        }

        /// <summary>
        /// 成功的动作响应
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <returns></returns>
        public HttpActionResponse<T> OkActionResponse<T>(T result)
        {
            return new HttpActionResponse<T>() { Result = result };
        }
    }
}
