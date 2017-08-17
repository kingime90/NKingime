﻿using NKingime.Core.Data;
using NKingime.Core.Ioc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NKingime.Core.Service
{
    /// <summary>
    /// 服务接口
    /// </summary>
    public interface IService<TEntity> : IService where TEntity : IEntity
    {

        /// <summary>
        /// 保存单个数据实体（新增）
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        int Save(TEntity entity);

        /// <summary>
        /// 保存数据实体集合（新增）
        /// </summary>
        /// <param name="entities">数据实体集合</param>
        /// <returns></returns>
        int Save(IEnumerable<TEntity> entities);

        /// <summary>
        /// 删除单个数据实体
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        int Delete(TEntity entity);

        /// <summary>
        /// 删除数据实体集合
        /// </summary>
        /// <param name="entities">数据实体集合</param>
        /// <returns></returns>
        int Delete(IEnumerable<TEntity> entities);

        /// <summary>
        /// 根据主键删除单个数据实体
        /// </summary>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="key">主键值</param>
        /// <returns></returns>
        int DeleteById<TKey>(TKey key);

        /// <summary>
        /// 更新单个数据实体
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        int Update(TEntity entity);

        /// <summary>
        /// 更新数据实体集合
        /// </summary>
        /// <param name="entities">数据实体集合</param>
        /// <returns></returns>
        int Update(IEnumerable<TEntity> entities);

        /// <summary>
        /// 根据主键获取单个数据实体
        /// </summary>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="key">主键值</param>
        /// <returns></returns>
        TEntity GetById<TKey>(TKey key);

        /// <summary>
        /// 全部列表
        /// </summary>
        /// <returns></returns>
        List<TEntity> AllList();

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="predicate">筛选条件</param>
        /// <returns></returns>
        List<TEntity> QueryList(Expression<Func<TEntity, bool>> predicate);
    }

    /// <summary>
    /// 服务接口
    /// </summary>
    public interface IService : IDependency
    {

    }
}
