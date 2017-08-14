using NKingime.Core.Data;
using NKingime.DataAccess.IRepository;
using NKingime.Entity;
using System.Linq;

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public User GetByUsername(string username)
        {
            return DbEntities.FirstOrDefault(x => x.Username == username);
        }
    }
}
