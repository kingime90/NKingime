using NKingime.BusinessLogic.IService;
using NKingime.Core.Service;
using NKingime.DataAccess.IRepository;
using NKingime.Entity;

namespace NKingime.BusinessLogic.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class UserService : ServiceBase<User>, IUserService
    {

        private readonly IUserRepository _userRepository;

        /// <summary>
        /// 
        /// </summary>
        public UserService(IUserRepository userRepository)
        {
            EntityRepository = userRepository;
            _userRepository = userRepository;
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
