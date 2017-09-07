using NKingime.BusinessLogic.IService;
using NKingime.Core.Mvc;
using NKingime.Core.Util;
using NKingime.Entity;
using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace NKingime.Fight.Controllers
{
    /// <summary>
    /// 数据字典分类控制器
    /// </summary>
    public class DataDictSortController : TicketController
    {
        /// <summary>
        /// 数据字典分类服务接口
        /// </summary>
        private readonly IDataDictSortService _dataDictSortService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleService"></param>
        public DataDictSortController(IDataDictSortService dataDictSortService)
        {
            _dataDictSortService = dataDictSortService;
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
            Expression<Func<DataDictSort, bool>> predicate = null;
            if (keyword.Length > 0)
            {
                predicate = p => p.Name.Contains(keyword);
            }
            //
            var userList = QueryPaging(_dataDictSortService, predicate, pageNumber, pageSize, sortName, sortOrder);
            return OkResult(PaginationUtil.ConvertToPagination(userList));
        }
    }
}