using NKingime.Core.Data;
using NKingime.Entity;

namespace NKingime.DataAccess.IRepository
{
    /// <summary>
    /// 用户数据仓储接口
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        User GetByUsername(string username);
    }
}
