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
    /// 数据字典控制器
    /// </summary>
    public class DataDictController : TicketController
    {
        /// <summary>
        /// 数据字典服务接口
        /// </summary>
        private readonly IDataDictService _dataDictService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleService"></param>
        public DataDictController(IDataDictService dataDictService)
        {
            _dataDictService = dataDictService;
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
        /// <param name="Name">排序名称</param>
        /// <param name="Order">排序方式</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpResponse Search(string keyword, int? pageNumber, int? pageSize, string sortName, string Order)
        {
            Expression<Func<DataDict, bool>> predicate = null;
            if (keyword.Length > 0)
            {
                predicate = p => p.Value.Contains(keyword);
            }
            //
            var userList = QueryPaging(_dataDictService, predicate, pageNumber, pageSize, sortName, Order);
            return OkResult(PaginationUtil.ConvertToPagination(userList));
        }
    }
}