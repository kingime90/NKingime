using NKingime.BusinessLogic.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NKingime.Fight.Controllers
{
    /// <summary>
    /// 用户控制器
    /// </summary>
    public class UserController : Controller
    {

        private readonly IUserService _userService;

        /// <summary>
        /// 
        /// </summary>
        public UserController()
        {

        }

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
    }
}