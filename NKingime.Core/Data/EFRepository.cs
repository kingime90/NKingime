using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

