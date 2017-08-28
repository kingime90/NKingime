using NKingime.BusinessLogic.IService;
using NKingime.Core.Define;
using NKingime.Core.Entity;
using NKingime.Core.Extentsion;
using NKingime.Core.Mvc;
using NKingime.Core.Util;
using NKingime.Entity;
using NKingime.Fight.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NKingime.Fight.Controllers
{
    /// <summary>
    /// 用户控制器
    /// </summary>
    public class UserController : TicketController
    {

        /// <summary>
        /// 用户服务接口
        /// </summary>
        private readonly IUserService _userService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userService"></param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetById(int? userId)
        {
            var user = _userService.GetById(userId);
            return Json(user, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        /// <summary>
        /// Do登录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //
            var user = _userService.GetByUsername(model.Username);
            if (user == null || model.Password != user.Password)
            {
                ModelState.AddModelError("Password", "用户名不存在或密码错误！");
                return View(model);
            }
            //
            var now = DateTime.Now;
            var userData = new UserData { UserId = user.Id, Username = user.Username, Ticks = now.Ticks };
            var userDataBase64 = JsonUtil.Serialize(userData).ToBase64();
            var authTicket = new FormsAuthenticationTicket(1, user.Username, now, now.AddMinutes(FormsAuthentication.Timeout.Minutes), model.RememberMe, userDataBase64, FormsAuthentication.FormsCookiePath);
            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
            {
                HttpOnly = true,
                Secure = FormsAuthentication.RequireSSL,
                Path = FormsAuthentication.FormsCookiePath
            };
            if (FormsAuthentication.CookieDomain != null)
            {
                authCookie.Domain = FormsAuthentication.CookieDomain;
            }
            //
            if (model.RememberMe)
            {
                authCookie.Expires = authTicket.Expiration;
            }
            //
            Response.Cookies.Add(authCookie);
            return Redirect(!string.IsNullOrWhiteSpace(returnUrl) ? returnUrl : FormsAuthentication.DefaultUrl);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            var user = _userService.GetById(UserData.UserId);
            return View(user);
        }

        [HttpGet]
        public ActionResult List()
        {
            return View();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="searchText">关键字</param>
        /// <param name="pageNumber">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="sortName">排序名称</param>
        /// <param name="sortOrder">排序方式</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpResponse Search(string keyword, int? pageNumber, int? pageSize, string sortName, string sortOrder)
        {
            pageNumber = pageNumber.IfNull(1);
            pageSize = pageSize.IfNull(10);
            Expression<Func<User, bool>> predicate = p => true;
            keyword = keyword.GetString();
            sortOrder = sortOrder.GetString();
            if (keyword.Length > 0)
            {
                predicate = p => p.Username.Contains(keyword) || p.Nickname.Contains(keyword);
            }
            var orderBy = PaginationUtil.GetOrderBy(sortOrder);
            var userList = _userService.QueryPaging(pageNumber.Value, pageSize.Value, predicate, (queryable) =>
             {
                 return PaginationUtil.PagingOrder(queryable, sortName, orderBy);
             });
            return OkActionResponse(PaginationUtil.ConvertToPagination(userList));
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Json(new { success = true });
        }
    }
}