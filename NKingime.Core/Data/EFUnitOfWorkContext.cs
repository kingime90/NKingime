﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKingime.Core.Data
{
    /// <summary>
    /// EF工作单元上下文
    /// </summary>
    public class EFUnitOfWorkContext : UnitOfWorkContextBase
    {

        private DbContext _dbContext;

        /// <summary>
        /// 数据库上下文
        /// </summary>
        public override DbContext DbContext
        {
            get
            {
                return _dbContext;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public EFUnitOfWorkContext()
        {
            _dbContext = DbContextManage.DbContext();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        public EFUnitOfWorkContext(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
