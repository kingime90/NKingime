using NKingime.Core.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKingime.Core.Data
{

    /// <summary>
    /// 工作单元接口
    /// </summary>
    public interface IUnitOfWork
    {

        /// <summary>
        /// 工作单元是否已被提交
        /// </summary>
        bool IsCommitted { get; }

        /// <summary>
        /// 提交工作单元
        /// </summary>
        /// <returns></returns>
        int Commit();

        /// <summary>
        /// 回滚工作单元到未提交
        /// </summary>
        void Rollback();
    }
}
