using NKingime.Core.Data;
using NKingime.DataAccess.IRepository;
using NKingime.Entity;
using System.Linq;

namespace NKingime.DataAccess.Repository
{
    /// <summary>
    /// 功能模块数据仓储
    /// </summary>
    public class ModuleRepository : EFRepository<Module>, IModuleRepository
    {

        /// <summary>
        /// 
        /// </summary>
        public ModuleRepository()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workContext"></param>
        public ModuleRepository(IUnitOfWorkContext workContext) : base(workContext)
        {

        }
    }
}
