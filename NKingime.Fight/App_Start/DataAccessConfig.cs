using NKingime.Core.Data;
using NKingime.DataAccess.DbContext;

namespace NKingime.Fight
{
    /// <summary>
    /// 数据访问配置
    /// </summary>
    public class DataAccessConfig
    {
        /// <summary>
        /// 注册数据访问配置
        /// </summary>
        public static void Register()
        {
            UnitOfWorkContextManage.Register(RegisterWorkContext);
            DbContextManage.Register(RegisterDbContext);
        }

        /// <summary>
        /// 注册工作单元上下
        /// </summary>
        /// <returns></returns>
        public static EFUnitOfWorkContext RegisterWorkContext()
        {
            return new EFUnitOfWorkContext();
        }

        /// <summary>
        /// 注册数据库上下文
        /// </summary>
        /// <returns></returns>
        public static NKingimeDb RegisterDbContext()
        {
            return new NKingimeDb();
        }
    }
}