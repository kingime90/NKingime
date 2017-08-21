﻿using NKingime.BusinessLogic.IService;
using NKingime.Core.Entity;
using NKingime.Core.Extentsion;
using NKingime.Core.Mvc;
using NKingime.Core.Util;
using NKingime.Fight.ViewModels;
using System;
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

        private readonly IUserService userService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userService"></param>
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetById(int? userId)
        {
            var user = userService.GetById(userId);
            return Json(user, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
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
        /// 
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
            var user = userService.GetByUsername(model.Username);
            if (user == null || model.Password != user.Password)
            {
                ModelState.AddModelError("Password", "用户名不存在或密码错误！");
                return View();
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
            var user = userService.GetById(UserData.UserId);
            return View(user);
        }

        [HttpGet]
        public ActionResult List()
        {
            var userList = userService.AllList();
            return View(userList);
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