using System;

namespace NKingime.Core.Data
{
    /// <summary>
    /// 数据实体基类
    /// </summary>
    /// <typeparam name="TKey">主键类型</typeparam>
    public class EntityBase<TKey> : IEntity
    {

        /// <summary>
        /// 主键
        /// </summary>
        public TKey Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public Nullable<DateTime> CreatedTime { get; set; }
    }
}
