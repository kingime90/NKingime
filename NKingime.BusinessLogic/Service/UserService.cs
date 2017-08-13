using NKingime.BusinessLogic.IService;
using NKingime.Core.Data;
using NKingime.Core.Service;
using NKingime.DataAccess.IRepository;
using NKingime.Entity.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKingime.BusinessLogic.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class UserService : ServiceBase<User>, IUserService
    {

        /// <summary>
        /// 
        /// </summary>
        public UserService(IUserRepository userRepository)
        {
            EntityRepository = userRepository;
        }
    }
}
