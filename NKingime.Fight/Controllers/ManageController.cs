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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}