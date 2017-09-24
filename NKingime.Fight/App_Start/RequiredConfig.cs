using NKingime.Core.Data;
using NKingime.Core.Log;
using NKingime.DataAccess.DbContext;

namespace NKingime.Fight
{
    /// <summary>
    /// 必要的配置
    /// </summary>
    public class RequiredConfig
    {

        /// <summary>
        /// 注册必要的配置
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

        /// <summary>
        /// 注册日志记录器
        /// </summary>
        /// <returns></returns>
        public static ILogger RegisterLogger()
        {
            return new Log4NetLogger();
        }
    }
}