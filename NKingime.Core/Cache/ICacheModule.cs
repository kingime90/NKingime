using NKingime.Core.Define;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKingime.Core.Cache
{
    /// <summary>
    /// 缓存模块接口
    /// </summary>
    public interface ICacheModule
    {

        /// <summary>
        /// 是否启用
        /// </summary>
        bool Enabled { get; }

        /// <summary>
        /// 缓存分类
        /// </summary>
        CacheSortFlag CacheSort { get; }

        void Load();
    }
}
