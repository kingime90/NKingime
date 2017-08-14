using NKingime.Core.Data;
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
        /// 列表（全部）
        /// </summary>
        /// <returns></returns>
        List<TEntity> List();

        /// <summary>
        /// 基于谓词筛选列表
        /// </summary>
        /// <param name="predicate">用于测试每个元素是否满足条件的函数</param>
        /// <returns></returns>
        List<TEntity> List(Expression<Func<TEntity, bool>> predicate);
    }

    /// <summary>
    /// 服务接口
    /// </summary>
    public interface IService : IDependency
    {

    }
}
