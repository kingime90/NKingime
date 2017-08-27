using NKingime.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
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
        /// <typeparam name="T"></typeparam>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public static BootstrapPagination<T> ConvertToPagination<T>(Pagination<T> pagination)
        {
            return new BootstrapPagination<T>
            {
                total = pagination.TotalCount,
                rows = pagination.List
            };
        }
    }
}
