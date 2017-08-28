﻿using NKingime.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NKingime.Core.Define;
using NKingime.Core.Entity;
using NKingime.Core.Data;

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
        /// 默认分页排序
        /// </summary>
        public abstract Func<IQueryable<TEntity>, IQueryable<TEntity>> PagingOrder { get; }

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
        /// 记录数
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return DbEntities.Count();
        }

        /// <summary>
        /// 记录数
        /// </summary>
        /// <param name="predicate">筛选条件</param>
        /// <returns></returns>
        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate != null)
            {
                return DbEntities.Count(predicate);
            }
            return Count();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public List<TEntity> Query()
        {
            return DbEntities.ToList();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="TKey">排序键</typeparam>
        /// <param name="keySelector">用于从元素中提取键的函数</param>
        /// <param name="orderBy">排序方式（默认 Asc）</param>
        /// <returns></returns>
        public List<TEntity> Query<TKey>(Expression<Func<TEntity, TKey>> keySelector, OrderBy orderBy)
        {
            return Query(null, keySelector, orderBy);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="orderSelector">排序选择委托</param>
        /// <returns></returns>
        public List<TEntity> Query(Func<IQueryable<TEntity>, IQueryable<TEntity>> orderSelector)
        {
            return Query(null, orderSelector);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="predicate">筛选条件</param>
        /// <returns></returns>
        public List<TEntity> Query(Expression<Func<TEntity, bool>> predicate)
        {
            return Query(predicate, null);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="TKey">排序键</typeparam>
        /// <param name="predicate">筛选条件</param>
        /// <param name="keySelector">用于从元素中提取键的函数</param>
        /// <param name="orderBy">排序方式（默认 Asc）</param>
        /// <returns></returns>
        public List<TEntity> Query<TKey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> keySelector, OrderBy orderBy)
        {
            var queryable = DbEntities;
            if (predicate != null)
            {
                queryable = queryable.Where(predicate);
            }
            //
            if (orderBy == OrderBy.Desc)
            {
                queryable = queryable.OrderByDescending(keySelector);
            }
            else
            {
                queryable = queryable.OrderBy(keySelector);
            }
            //
            return queryable.ToList();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="predicate">筛选条件</param>
        /// <param name="orderSelector">排序选择委托</param>
        /// <returns></returns>
        public List<TEntity> Query(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderSelector)
        {
            var queryable = DbEntities;
            if (predicate != null)
            {
                queryable = queryable.Where(predicate);
            }
            //
            if (orderSelector != null)
            {
                queryable = orderSelector(queryable);
            }
            //
            return queryable.ToList();
        }

        /// <summary>
        /// 查询分页
        /// </summary>
        /// <param name="pageNumber">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <returns></returns>
        public Pagination<TEntity> QueryPaging(int pageNumber, int pageSize)
        {
            return QueryPaging(pageNumber, pageSize, null, null);
        }

        /// <summary>
        /// 查询分页
        /// </summary>
        /// <param name="pageNumber">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="predicate">筛选条件</param>
        /// <returns></returns>
        public Pagination<TEntity> QueryPaging(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate)
        {
            return QueryPaging(pageNumber, pageSize, predicate, null);
        }

        /// <summary>
        /// 查询分页
        /// </summary>
        /// <typeparam name="TKey">排序键</typeparam>
        /// <param name="pageNumber">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="keySelector">用于从元素中提取键的函数</param
        /// <param name="orderBy">排序方式（默认 Asc）</param>
        /// <returns></returns>
        public Pagination<TEntity> QueryPaging<TKey>(int pageNumber, int pageSize, Expression<Func<TEntity, TKey>> keySelector, OrderBy orderBy)
        {
            return QueryPaging(pageNumber, pageSize, null, keySelector, orderBy);
        }

        /// <summary>
        /// 查询分页
        /// </summary>
        /// <param name="pageNumber">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="orderSelector">排序选择委托</param>
        /// <returns></returns>
        public Pagination<TEntity> QueryPaging(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderSelector)
        {
            return QueryPaging(pageNumber, pageSize, null, orderSelector);
        }

        /// <summary>
        /// 查询分页
        /// </summary>
        /// <typeparam name="TKey">排序键</typeparam>
        /// <param name="pageNumber">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="predicate">筛选条件</param>
        /// <param name="keySelector">用于从元素中提取键的函数</param
        /// <param name="orderBy">排序方式（默认 Asc）</param>
        /// <returns></returns>
        public Pagination<TEntity> QueryPaging<TKey>(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> keySelector, OrderBy orderBy)
        {
            var total = Count(predicate);
            var pagination = new Pagination<TEntity>(pageNumber, pageSize, total);
            if (total == 0)
            {
                pagination.List = new List<TEntity>();
                return pagination;
            }
            //
            var queryable = DbEntities;
            if (predicate != null)
            {
                queryable = queryable.Where(predicate);
            }
            //
            if (orderBy == OrderBy.Desc)
            {
                queryable = queryable.OrderByDescending(keySelector);
            }
            else
            {
                queryable = queryable.OrderBy(keySelector);
            }
            queryable = queryable.Skip(pagination.PageSize * (pagination.PageNumber - 1)).Take(pagination.PageSize);
            pagination.List = queryable.ToList();
            //
            return pagination;
        }

        /// <summary>
        /// 查询分页
        /// </summary>
        /// <param name="pageNumber">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="predicate">筛选条件</param>
        /// <param name="orderSelector">排序选择委托</param>
        /// <returns></returns>
        public Pagination<TEntity> QueryPaging(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderSelector)
        {
            var total = Count(predicate);
            var pagination = new Pagination<TEntity>(pageNumber, pageSize, total);
            if (total == 0)
            {
                pagination.List = new List<TEntity>();
                return pagination;
            }
            //
            var queryable = DbEntities;
            if (predicate != null)
            {
                queryable = queryable.Where(predicate);
            }
            //
            if (orderSelector == null)
            {
                orderSelector = PagingOrder;
            }
            queryable = orderSelector(queryable).Skip(pagination.PageSize * (pagination.PageNumber - 1)).Take(pagination.PageSize);
            pagination.List = queryable.ToList();
            //
            return pagination;
        }
    }
}
