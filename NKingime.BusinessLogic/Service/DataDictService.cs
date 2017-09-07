using NKingime.BusinessLogic.IService;
using NKingime.Core.Service;
using NKingime.DataAccess.IRepository;
using NKingime.Entity;
using System.Collections.Generic;
using System.Linq;

namespace NKingime.BusinessLogic.Service
{
    /// <summary>
    /// 数据字典服务
    /// </summary>
    public class DataDictService : ServiceBase<DataDict>, IDataDictService
    {

        private readonly IDataDictRepository _dataDictRepository;

        /// <summary>
        /// 
        /// </summary>
        public DataDictService(IDataDictRepository dataDictRepository)
        {
            EntityRepository = _dataDictRepository = dataDictRepository;
        }
    }
}
