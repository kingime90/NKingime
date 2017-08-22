using NKingime.BusinessLogic.IService;
using NKingime.Core.Service;
using NKingime.DataAccess.IRepository;
using NKingime.Entity;

namespace NKingime.BusinessLogic.Service
{
    /// <summary>
    /// 用户服务接口
    /// </summary>
    public class UserService : ServiceBase<User>, IUserService
    {

        private readonly IUserRepository _userRepository;

        /// <summary>
        /// 
        /// </summary>
        public UserService(IUserRepository userRepository)
        {
            EntityRepository = _userRepository = userRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public User GetByUsername(string username)
        {
            return _userRepository.GetByUsername(username);
        }
    }
}
