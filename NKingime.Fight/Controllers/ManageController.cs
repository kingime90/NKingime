﻿using NKingime.BusinessLogic.IService;
using NKingime.Core.Mvc;
using System.Web.Mvc;

namespace NKingime.Fight.Controllers
{
    /// <summary>
    /// 后台管理控制器
    /// </summary>
    public class ManageController : TicketController
    {
        /// <summary>
        /// 用户服务接口
        /// </summary>
        private readonly IUserService _userService;

        /// <summary>
        /// 功能模块服务接口
        /// </summary>
        private readonly IModuleService _moduleService;

        public ManageController(IUserService userService, IModuleService moduleService)
        {
            _userService = userService;
            _moduleService = moduleService;
        }

        /// <summary>
        /// 主页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            var user = _userService.GetById(UserData.UserId);
            ViewBag.ModuleList = _moduleService.GetListByUserId(UserData.UserId);
            return View(user);
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Home()
        {
            return View();
        }
    }
}