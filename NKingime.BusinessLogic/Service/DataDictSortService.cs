using NKingime.BusinessLogic.IService;
using NKingime.Core.Service;
using NKingime.DataAccess.IRepository;
using NKingime.Entity;
using System.Collections.Generic;
using System.Linq;

namespace NKingime.BusinessLogic.Service
{
    /// <summary>
    /// 数据字典分类服务
    /// </summary>
    public class DataDictSortService : ServiceBase<DataDictSort>, IDataDictSortService
    {

        private readonly IDataDictSortRepository _dataDictSortRepository;

        /// <summary>
        /// 
        /// </summary>
        public DataDictSortService(IDataDictSortRepository dataDictSortRepository)
        {
            EntityRepository = _dataDictSortRepository = dataDictSortRepository;
        }
    }
}
