using System;

namespace NKingime.Core.Data
{
    /// <summary>
    /// 工作单元上下管理
    /// </summary>
    public class UnitOfWorkContextManage
    {
        private static Func<IUnitOfWorkContext> _workContext;

        /// <summary>
        /// 工作单元上下
        /// </summary>
        public static Func<IUnitOfWorkContext> WorkContext
        {
            get
            {
                return _workContext;
            }
        }

        /// <summary>
        /// 注册工作单元上下
        /// </summary>
        /// <param name="workContext"></param>
        public static void Register(Func<IUnitOfWorkContext> workContext)
        {
            _workContext = workContext;
        }
    }
}
