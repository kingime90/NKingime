using NKingime.Core.Data;
using NKingime.Core.Define;
using NKingime.Core.Entity;
using NKingime.Core.Extentsion;
using NKingime.Core.Service;
using NKingime.Core.Util;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Web.Mvc;

namespace NKingime.Core.Mvc
{
    /// <summary>
    /// 令牌控制器基类
    /// </summary>
    public abstract class TicketController : Controller
    {

        /// <summary>
        /// 
        /// </summary>
        public TicketController() : base()
        {

        }

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
        /// 成功的动作响应
        /// </summary>
        /// <returns></returns>
        public HttpActionResponse Ok()
        {
            return new HttpActionResponse();
        }

        /// <summary>
        /// 成功的动作响应结果
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <returns></returns>
        public HttpActionResponse<T> OkResult<T>(T result)
        {
            return new HttpActionResponse<T>() { Result = result };
        }

        /// <summary>
        /// 查询分页 
        /// </summary>
        /// <typeparam name="TEntity">数据实体</typeparam>
        /// <param name="service">服务接口</param>
        /// <param name="predicate">筛选条件</param>
        /// <param name="pageNumber">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="sortOrder">排序方式</param>
        /// <param name="orderSelector">排序选择委托</param>
        /// <returns></returns>
        protected Pagination<TEntity> QueryPaging<TEntity>(IService<TEntity> service, Expression<Func<TEntity, bool>> predicate, int? pageNumber, int? pageSize, string sortOrder, Func<IQueryable<TEntity>, OrderBy, IQueryable<TEntity>> orderSelector) where TEntity : IEntity
        {
            return PaginationUtil.QueryPaging<TEntity>(service, predicate, pageNumber, pageSize, sortOrder, orderSelector);
        }

        /// <summary>
        /// 查询分页
        /// </summary>
        /// <typeparam name="TEntity">数据实体</typeparam>
        /// <param name="service">服务接口</param>
        /// <param name="predicate">筛选条件</param>
        /// <param name="pageNumber">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="sortName">排序名称</param>
        /// <param name="sortOrder">排序方式</param>
        /// <returns></returns>
        protected Pagination<TEntity> QueryPaging<TEntity>(IService<TEntity> service, Expression<Func<TEntity, bool>> predicate, int? pageNumber, int? pageSize, string sortName, string sortOrder) where TEntity : IEntity
        {
            return PaginationUtil.QueryPaging(service, predicate, pageNumber, pageSize, sortName, sortOrder);
        }
    }
}
