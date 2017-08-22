using NKingime.Core.Service;
using NKingime.Entity;
using System.Collections.Generic;

namespace NKingime.BusinessLogic.IService
{
    /// <summary>
    /// 功能模块服务接口
    /// </summary>
    public interface IModuleService : IService<Module>
    {
        /// <summary>
        /// 根据用户ID获取功能模块列表
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        List<Module> GetListByUserId(int userId);
    }
}
