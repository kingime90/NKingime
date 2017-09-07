using NKingime.BusinessLogic.IService;
using NKingime.Core.Mvc;
using NKingime.Core.Util;
using NKingime.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace NKingime.Fight.Controllers
{
    /// <summary>
    /// 角色控制器
    /// </summary>
    public class RoleController : TicketController
    {
        /// <summary>
        /// 角色服务接口
        /// </summary>
        private readonly IRoleService _roleService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleService"></param>
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
            Expression<Func<Role, bool>> predicate = null;
            if (keyword.Length > 0)
            {
                predicate = p => p.Name.Contains(keyword);
            }
            //
            var userList = QueryPaging(_roleService, predicate, pageNumber, pageSize, sortName, sortOrder);
            return OkResult(PaginationUtil.ConvertToPagination(userList));
        }
    }
}