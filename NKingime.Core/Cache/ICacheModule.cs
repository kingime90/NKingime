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
        /// 优先级
        /// </summary>
        int Priority { get; }

        /// <summary>
        /// 缓存分类
        /// </summary>
        CacheSortFlag CacheSort { get; }

        /// <summary>
        /// 获取是否启用
        /// </summary>
        /// <returns></returns>
        bool GetEnabled();

        /// <summary>
        /// 获取缓存键
        /// </summary>
        /// <returns></returns>
        string GetCacheKey();

        /// <summary>
        /// 加载
        /// </summary>
        void Load();
    }
}
