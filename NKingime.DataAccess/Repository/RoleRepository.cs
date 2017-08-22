using NKingime.Core.Data;
using NKingime.DataAccess.IRepository;
using NKingime.Entity;
using System.Linq;

namespace NKingime.DataAccess.Repository
{
    /// <summary>
    /// 角色数据仓储
    /// </summary>
    public class RoleRepository : EFRepository<Role>, IRoleRepository
    {

        /// <summary>
        /// 
        /// </summary>
        public RoleRepository()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workContext"></param>
        public RoleRepository(IUnitOfWorkContext workContext) : base(workContext)
        {

        }
    }
}
