using NKingime.Core.Define;
using NKingime.Core.Entity;
using System.Web.Mvc;

namespace NKingime.Core.Mvc
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class TicketController : Controller
    {

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
        /// 
        /// </summary>
        public TicketController() : base()
        {

        }
    }
}
