using NKingime.BusinessLogic.IService;
using NKingime.Core.Service;
using NKingime.DataAccess.IRepository;
using NKingime.Entity;

namespace NKingime.BusinessLogic.Service
{
    /// <summary>
    /// 角色服务
    /// </summary>
    public class RoleService : ServiceBase<Role>, IRoleService
    {

        private readonly IRoleRepository _roleService;

        /// <summary>
        /// 
        /// </summary>
        public RoleService(IRoleRepository roleService)
        {
            EntityRepository = _roleService = roleService;
        }
    }
}
