using NKingime.Core.Ioc;

namespace NKingime.Core.Data
{
    /// <summary>
    /// 数据事物管理接口
    /// </summary>
    public interface ITransactionManage : IDependency
    {

        /// <summary>
        /// 工作单元上下文接口
        /// </summary>
        IUnitOfWorkContext WorkContext { get; }

        /// <summary>
        /// 创建数据仓储
        /// </summary>
        /// <typeparam name="T">数据仓储类型</typeparam>
        T Create<T>() where T : IRepository;
    }
}
