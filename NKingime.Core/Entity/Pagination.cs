﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKingime.Core.Entity
{
    /// <summary>
    /// 分页
    /// </summary>
    public class Pagination<TEntity>
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="totalCount">总记录</param>
        /// <param name="pageCount">总页数</param>
        public Pagination(int pageIndex, int pageSize, int totalCount)
        {
            if (pageSize <= 0)
            {
                pageSize = 10;
            }
            PageSize = pageSize;
            //
            if (totalCount < 0)
            {
                totalCount = 0;
            }
            TotalCount = totalCount;
            //
            PageCount = totalCount % pageSize == 0 ? totalCount / pageSize : totalCount / pageSize + 1;
            //
            if (pageIndex <= 0 || PageCount == 0)
            {
                pageIndex = 1;
            }
            if (pageIndex > PageCount && PageCount != 0)
            {
                pageIndex = PageCount;
            }
            PageIndex = pageIndex;
            //
        }

        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; private set; }

        /// <summary>
        /// 页大小
        /// </summary>
        public int PageSize { get; private set; }

        /// <summary>
        /// 总记录
        /// </summary>
        public int TotalCount { get; private set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount { get; private set; }

        /// <summary>
        /// 分页列表
        /// </summary>
        public IEnumerable<TEntity> List { get; set; }
    }
}
