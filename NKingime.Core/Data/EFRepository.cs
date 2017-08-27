using System;
using System.Linq;

namespace NKingime.Core.Data
{
    /// <summary>
    /// EF数据仓储
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class EFRepository<TEntity> : RepositoryBase<TEntity> where TEntity : class, IEntity
    {

        private IUnitOfWorkContext _workContext;

        /// <summary>
        /// 工作单元上下文接口
        /// </summary>
        public override IUnitOfWorkContext WorkContext
        {
            get
            {
                return _workContext;
            }
        }

        /// <summary>
        /// 默认分页排序
        /// </summary>
        public override Func<IQueryable<TEntity>, IQueryable<TEntity>> PagingOrder
        {
            get
            {
                return q => q.OrderByDescending(p => p.CreatedTime);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public EFRepository()
        {
            _workContext = UnitOfWorkContextManage.WorkContext();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workContext">工作单元上下文接口</param>
        public EFRepository(IUnitOfWorkContext workContext)
        {
            _workContext = workContext;
        }
    }
}

