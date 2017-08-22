using NKingime.Core.Service;
using NKingime.Entity;

namespace NKingime.BusinessLogic.IService
{
    /// <summary>
    /// 用户服务接口
    /// </summary>
    public interface IUserService : IService<User>
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        User GetByUsername(string username);
    }
}
