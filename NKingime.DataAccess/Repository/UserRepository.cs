using NKingime.Core.Data;
using NKingime.DataAccess.IRepository;
using NKingime.Entity.Mapping;

namespace NKingime.DataAccess.Repository
{
    /// <summary>
    /// 用户数据仓储
    /// </summary>
    public class UserRepository : EFRepository<User>, IUserRepository
    {

        /// <summary>
        /// 
        /// </summary>
        public UserRepository()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workContext"></param>
        public UserRepository(IUnitOfWorkContext workContext) : base(workContext)
        {

        }
    }
}
