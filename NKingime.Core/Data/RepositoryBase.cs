using NKingime.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NKingime.Core.Data
{
    /// <summary>
    /// 数据仓储基类
    /// </summary>
    /// <typeparam name="TEntity">数据实体类型</typeparam>
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {

        /// <summary>
        /// 工作单元上下文接口
        /// </summary>
        public abstract IUnitOfWorkContext WorkContext { get; }

        /// <summary>
        /// 当前查询数据实体集合
        /// </summary>
        public virtual IQueryable<TEntity> DbEntities
        {
            get
            {
                return WorkContext.Set<TEntity>();
            }
        }

        /// <summary>
        /// 保存单个数据实体（新增）
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <param name="saveChange">是否执行保存</param>
        /// <returns></returns>
        public virtual int Save(TEntity entity, bool saveChange = true)
        {
            ArgumentUtil.ThrowIfNull(entity, nameof(entity));
            //
            WorkContext.RegisterNew(entity);
            return saveChange ? WorkContext.Commit() : 0;
        }

        /// <summary>
        /// 保存数据实体集合（新增）
        /// </summary>
        /// <param name="entities">数据实体集合</param>
        /// <param name="saveChange">是否执行保存</param>
        /// <returns></returns>
        public virtual int Save(IEnumerable<TEntity> entities, bool saveChange = true)
        {
            ArgumentUtil.ThrowIfNull(entities, nameof(entities));
            //
            WorkContext.RegisterNew(entities);
            return saveChange ? WorkContext.Commit() : 0;
        }

        /// <summary>
        /// 删除单个数据实体
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <param name="saveChange">是否执行删除</param>
        /// <returns></returns>
        public virtual int Delete(TEntity entity, bool saveChange = true)
        {
            ArgumentUtil.ThrowIfNull(entity, nameof(entity));
            //
            WorkContext.RegisterDeleted(entity);
            return saveChange ? WorkContext.Commit() : 0;
        }

        /// <summary>
        /// 删除数据实体集合
        /// </summary>
        /// <param name="entities">数据实体集合</param>
        /// <param name="saveChange">是否执行删除</param>
        /// <returns></returns>
        public virtual int Delete(IEnumerable<TEntity> entities, bool saveChange = true)
        {
            ArgumentUtil.ThrowIfNull(entities, nameof(entities));
            //
            WorkContext.RegisterDeleted(entities);
            return saveChange ? WorkContext.Commit() : 0;
        }

        /// <summary>
        /// 根据主键删除单个数据实体
        /// </summary>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="key">主键值</param>
        /// <param name="saveChange">是否执行删除</param>
        /// <returns></returns>
        public virtual int DeleteById<TKey>(TKey key, bool saveChange = true)
        {
            ArgumentUtil.Validate(key != null, nameof(key));
            //
            var entity = GetById(key);
            if (entity == null)
            {
                return 0;
            }
            //
            return Delete(entity, saveChange);
        }

        /// <summary>
        /// 更新单个数据实体
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <param name="saveChange">是否执行更新</param>
        /// <returns></returns>
        public virtual int Update(TEntity entity, bool saveChange = true)
        {
            ArgumentUtil.ThrowIfNull(entity, nameof(entity));
            //
            WorkContext.RegisterModified(entity);
            return saveChange ? WorkContext.Commit() : 0;
        }

        /// <summary>
        /// 更新数据实体集合
        /// </summary>
        /// <param name="entities">数据实体集合</param>
        /// <param name="saveChange">是否执行更新</param>
        /// <returns></returns>
        public virtual int Update(IEnumerable<TEntity> entities, bool saveChange = true)
        {
            ArgumentUtil.ThrowIfNull(entities, nameof(entities));
            //
            WorkContext.RegisterModified(entities);
            return saveChange ? WorkContext.Commit() : 0;
        }

        /// <summary>
        /// 根据主键获取单个数据实体
        /// </summary>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="key">主键值</param>
        /// <returns></returns>
        public virtual TEntity GetById<TKey>(TKey key)
        {
            ArgumentUtil.Validate(key != null, nameof(key));
            //
            return WorkContext.Set<TEntity>().Find(key);
        }

        /// <summary>
        /// 列表（全部）
        /// </summary>
        /// <returns></returns>
        public List<TEntity> List()
        {
            return DbEntities.ToList();
        }

        /// <summary>
        /// 基于谓词筛选列表
        /// </summary>
        /// <param name="predicate">用于测试每个元素是否满足条件的函数</param>
        /// <returns></returns>
        public List<TEntity> List(Expression<Func<TEntity, bool>> predicate)
        {
            return DbEntities.Where(predicate).ToList();
        }
    }
}
