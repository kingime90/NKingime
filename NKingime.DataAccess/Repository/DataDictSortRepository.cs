using NKingime.Core.Data;
using NKingime.DataAccess.IRepository;
using NKingime.Entity;

namespace NKingime.DataAccess.Repository
{
    /// <summary>
    /// 数据字典分类数据仓储
    /// </summary>
    public class DataDictSortRepository : EFRepository<DataDictSort>, IDataDictSortRepository
    {
        
        /// <summary>
        /// 
        /// </summary>
        public DataDictSortRepository()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workContext"></param>
        public DataDictSortRepository(IUnitOfWorkContext workContext) : base(workContext)
        {

        }
    }
}
