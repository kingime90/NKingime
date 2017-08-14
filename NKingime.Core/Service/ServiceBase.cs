using NKingime.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NKingime.Core.Service
{
    /// <summary>
    /// 服务基类
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class ServiceBase<TEntity> : IService<TEntity> where TEntity : IEntity
    {

        /// <summary>
        /// 数据实体仓储
        /// </summary>
        protected IRepository<TEntity> EntityRepository { get; set; }

        /// <summary>
        /// 保存单个数据实体（新增）
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        public int Save(TEntity entity)
        {
            return EntityRepository.Save(entity);
        }

        /// <summary>
        /// 保存数据实体集合（新增）
        /// </summary>
        /// <param name="entities">数据实体集合</param>
        /// <returns></returns>
        public int Save(IEnumerable<TEntity> entities)
        {
            return EntityRepository.Save(entities);
        }

        /// <summary>
        /// 删除单个数据实体
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        public int Delete(TEntity entity)
        {
            return EntityRepository.Delete(entity);
        }

        /// <summary>
        /// 删除数据实体集合
        /// </summary>
        /// <param name="entities">数据实体集合</param>
        /// <returns></returns>
        public int Delete(IEnumerable<TEntity> entities)
        {
            return EntityRepository.Delete(entities);
        }

        /// <summary>
        /// 根据主键删除单个数据实体
        /// </summary>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="key">主键值</param>
        /// <returns></returns>
        public int DeleteById<TKey>(TKey key)
        {
            return EntityRepository.DeleteById(key);
        }

        /// <summary>
        /// 更新单个数据实体
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns></returns>
        public int Update(TEntity entity)
        {
            return EntityRepository.Update(entity);
        }

        /// <summary>
        /// 更新数据实体集合
        /// </summary>
        /// <param name="entities">数据实体集合</param>
        /// <returns></returns>
        public int Update(IEnumerable<TEntity> entities)
        {
            return EntityRepository.Update(entities);
        }

        /// <summary>
        /// 根据主键获取单个数据实体
        /// </summary>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="key">主键值</param>
        /// <returns></returns>
        public TEntity GetById<TKey>(TKey key)
        {
            return EntityRepository.GetById(key);
        }

        /// <summary>
        /// 列表（全部）
        /// </summary>
        /// <returns></returns>
        public List<TEntity> List()
        {
            return EntityRepository.List();
        }

        /// <summary>
        /// 基于谓词筛选列表
        /// </summary>
        /// <param name="predicate">用于测试每个元素是否满足条件的函数</param>
        /// <returns></returns>
        public List<TEntity> List(Expression<Func<TEntity, bool>> predicate)
        {
            return EntityRepository.List(predicate);
        }
    }
}
