﻿using NKingime.Core.Data;
using NKingime.Core.Ioc;

namespace NKingime.Core.Service
{
    /// <summary>
    /// 服务接口
    /// </summary>
    public interface IService<TEntity> : IService where TEntity : IEntity
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Save(TEntity entity);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        TEntity GetById<TKey>(TKey key);
    }

    /// <summary>
    /// 服务接口
    /// </summary>
    public interface IService : IDependency
    {

    }
}
