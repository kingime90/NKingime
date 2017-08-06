﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
