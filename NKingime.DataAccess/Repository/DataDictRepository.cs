using NKingime.Core.Data;
using NKingime.DataAccess.IRepository;
using NKingime.Entity;

namespace NKingime.DataAccess.Repository
{
    /// <summary>
    /// 数据字典分类数据仓储
    /// </summary>
    public class DataDictRepository : EFRepository<DataDict>, IDataDictRepository
    {

        /// <summary>
        /// 
        /// </summary>
        public DataDictRepository()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workContext"></param>
        public DataDictRepository(IUnitOfWorkContext workContext) : base(workContext)
        {

        }
    }
}
