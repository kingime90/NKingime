using NKingime.Core.Data;
using NKingime.Entity.Mapping;
using NKingime.IRepository;

namespace NKingime.Repository
{
    /// <summary>
    /// 用户数据仓储
    /// </summary>
    public class UserRepository : EFRepository<User>, IUserRepository
    {

    }
}
