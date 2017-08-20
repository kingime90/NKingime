using NKingime.BusinessLogic.IService;
using NKingime.Core.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NKingime.Fight.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class ManageController : TicketController
    {

        private readonly IUserService userService;

        public ManageController(IUserService userService)
        {
            this.userService = userService;
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
    }
}