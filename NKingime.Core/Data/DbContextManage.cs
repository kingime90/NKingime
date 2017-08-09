using System;
using System.Data.Entity;

namespace NKingime.Core.Data
{
    /// <summary>
    /// 数据库上下文管理
    /// </summary>
    public class DbContextManage
    {

        private static Func<DbContext> _dbContext;

        /// <summary>
        /// 数据库上下文
        /// </summary>
        public static Func<DbContext> DbContext
        {
            get
            {
                return _dbContext;
            }
        }

        /// <summary>
        /// 注册数据库上下文
        /// </summary>
        /// <param name="workContext"></param>
        public static void Register(Func<DbContext> dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
