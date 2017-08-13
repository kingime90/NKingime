using Autofac;
using NKingime.Core.Ioc;

namespace NKingime.Core.Data
{
    /// <summary>
    /// 数据事物管理
    /// </summary>
    public class TransactionManage : ITransactionManage
    {

        private IUnitOfWorkContext _workContext;

        /// <summary>
        /// 工作单元上下文接口
        /// </summary>
        public IUnitOfWorkContext WorkContext
        {
            get
            {
                return _workContext;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public TransactionManage()
        {
            _workContext = UnitOfWorkContextManage.WorkContext();
        }

        /// <summary>
        /// 创建数据仓储
        /// </summary>
        /// <typeparam name="T">数据仓储类型</typeparam>
        /// <returns></returns>
        public T Create<T>() where T : IRepository
        {
            return IocContainerManage.IocContainer.Resolve<T>(new TypedParameter(typeof(IUnitOfWorkContext), _workContext));
        }
    }
}
