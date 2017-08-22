using NKingime.BusinessLogic.IService;
using NKingime.Core.Service;
using NKingime.DataAccess.IRepository;
using NKingime.Entity;
using System.Collections.Generic;
using System.Linq;

namespace NKingime.BusinessLogic.Service
{
    /// <summary>
    /// 功能模块服务
    /// </summary>
    public class ModuleService : ServiceBase<Module>, IModuleService
    {

        private readonly IModuleRepository _moduleRepository;

        /// <summary>
        /// 
        /// </summary>
        public ModuleService(IModuleRepository moduleRepository)
        {
            EntityRepository = _moduleRepository = moduleRepository;
        }

        /// <summary>
        /// 根据用户ID获取功能模块列表
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public List<Module> GetListByUserId(int userId)
        {
            var modules = _moduleRepository.AllList();
            return BuildChilds(modules);
        }

        /// <summary>
        /// 构建功能模块子节点（递归）
        /// </summary>
        /// <param name="modules">模块列表</param>
        /// <param name="parentId">父模块ID</param>
        /// <returns></returns>
        public List<Module> BuildChilds(List<Module> modules, int? parentId = null)
        {
            var roots = modules.FindAll(p => p.ParentId == parentId);
            foreach (var root in roots)
            {
                root.Childs = BuildChilds(modules, root.Id);
            }
            return roots;
        }
    }
}
