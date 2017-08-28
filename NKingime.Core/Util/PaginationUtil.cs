using NKingime.Core.Define;
using NKingime.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NKingime.Core.Util
{
    /// <summary>
    /// 分页工具
    /// </summary>
    public class PaginationUtil
    {
        /// <summary>
        /// 转换到分页
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
        public static IQueryable<T> PagingOrder<T>(IQueryable<T> queryable, string propertyName, OrderBy orderBy)
        {
            //参数 p， p=>p.
            var param = Expression.Parameter(typeof(T), "p");
            var body = Expression.Property(param, propertyName);
            dynamic keySelector = Expression.Lambda(body, param);
            if (orderBy == OrderBy.Desc)
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
        public static OrderBy GetOrderBy(string sortOrder, OrderBy defaultValue = OrderBy.Asc)
        {
            return EnumUtil.ConvertToEnum<OrderBy>(sortOrder, defaultValue, null);
        }
    }
}
