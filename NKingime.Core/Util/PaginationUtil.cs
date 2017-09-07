using NKingime.Core.Config;
using NKingime.Core.Data;
using NKingime.Core.Define;
using NKingime.Core.Entity;
using NKingime.Core.Extentsion;
using NKingime.Core.Service;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace NKingime.Core.Util
{
    /// <summary>
    /// 分页工具
    /// </summary>
    public class PaginationUtil
    {

        /// <summary>
        /// 转换Bootstrap分页
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="pagination">分页</param>
        /// <returns></returns>
        public static BootstrapPagination<T> ConvertToPagination<T>(Pagination<T> pagination)
        {
            return new BootstrapPagination<T>
            {
                pageNumber = pagination.PageNumber,
                pageSize = pagination.PageSize,
                total = pagination.TotalCount,
                rows = pagination.List
            };
        }

        /// <summary>
        /// 根据属性名称排序
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="queryable">查询数据实体集合</param>
        /// <param name="propertyName">属性名称</param>
        /// <param name="orderBy">排序方式</param>
        /// <returns></returns>
        public static IQueryable<T> PagingOrder<T>(IQueryable<T> queryable, string propertyName, OrderByFlag orderBy)
        {
            //参数 p， p=>p.
            var param = Expression.Parameter(typeof(T), "p");
            var body = Expression.Property(param, propertyName);
            dynamic keySelector = Expression.Lambda(body, param);
            if (orderBy == OrderByFlag.Desc)
            {
                return Queryable.OrderByDescending(queryable, keySelector);
            }
            else
            {
                return Queryable.OrderBy(queryable, keySelector);
            }
        }

        /// <summary>
        /// 获取排序方式
        /// </summary>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        public static OrderByFlag GetOrderBy(string sortOrder, OrderByFlag defaultValue = OrderByFlag.Asc)
        {
            return EnumUtil.ConvertToEnum<OrderByFlag>(sortOrder, defaultValue, null);
        }

        /// <summary>
        /// 获取视图分页首页页码
        /// </summary>
        public static int GetViewPageNumber(int? pageNumber)
        {
            return pageNumber.IfNull(AppSettingConfig.ViewPageNumber).Value;
        }

        /// <summary>
        /// 获取视图分页页大小
        /// </summary>
        public static int GetViewPageSize(int? pageSize)
        {
            return pageSize.IfNull(AppSettingConfig.ViewPageSize).Value;
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
        public static Pagination<TEntity> QueryPaging<TEntity>(IService<TEntity> service, Expression<Func<TEntity, bool>> predicate, int? pageNumber, int? pageSize, string sortOrder, Func<IQueryable<TEntity>, OrderByFlag, IQueryable<TEntity>> orderSelector) where TEntity : IEntity
        {
            pageNumber = GetViewPageNumber(pageNumber);
            pageSize = GetViewPageSize(pageSize);
            var orderBy = GetOrderBy(sortOrder);
            return service.QueryPaging(pageNumber.Value, pageSize.Value, predicate, (queryable) =>
            {
                return orderSelector(queryable, orderBy);
            });
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
        public static Pagination<TEntity> QueryPaging<TEntity>(IService<TEntity> service, Expression<Func<TEntity, bool>> predicate, int? pageNumber, int? pageSize, string sortName, string sortOrder) where TEntity : IEntity
        {
            return QueryPaging(service, predicate, pageNumber, pageSize, sortOrder, (queryable, orderBy) =>
            {
                return PagingOrder(queryable, sortName, orderBy);
            });
        }
    }
}
