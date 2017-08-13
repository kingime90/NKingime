using NKingime.Core.Service;
using NKingime.Entity.Mapping;

namespace NKingime.BusinessLogic.IService
{
    /// <summary>
    /// 
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
