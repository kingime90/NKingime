using NKingime.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NKingime.Core.Entity
{
    /// <summary>
    /// Bootstrap分页
    /// </summary>
    public class BootstrapPagination<T>
    {
        /// <summary>
        /// 总记录
        /// </summary>
        public int total { get; set; }

        /// <summary>
        /// 列表
        /// </summary>
        public IEnumerable<T> rows { get; set; }
    }
}