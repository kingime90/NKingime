﻿using NKingime.Core.Define;
using NKingime.Core.Entity;
using NKingime.Core.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NKingime.Core.Data
{
    /// <summary>
    /// 数据仓储接口
    /// </summary>
    /// <typeparam name="TEntity">数据实体类型</typeparam>
    public interface IRepository<TEntity> : IRepository where TEntity : IEntity
    {

        /// <summary>
        /// 工作单元上下文接口
        /// </summary>
        IUnitOfWorkContext WorkContext { get; }

        /// <summary>
        /// 当前查询数据实体集合
        /// </summary>
        IQueryable<TEntity> DbEntities { get; }

        /// <summary>
        /// 默认分页排序
        /// </summary>
        Func<IQueryable<TEntity>, IQueryable<TEntity>> PagingOrder { get; }

        /// <summary>
        /// 保存单个数据实体（新增）
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <param name="saveChange">是否执行保存</param>
        /// <returns></returns>
        int Save(TEntity entity, bool saveChange = true);

        /// <summary>
        /// 保存数据实体集合（新增）
        /// </summary>
        /// <param name="entities">数据实体集合</param>
        /// <param name="saveChange">是否执行保存</param>
        /// <returns></returns>
        int Save(IEnumerable<TEntity> entities, bool saveChange = true);

        /// <summary>
        /// 删除单个数据实体
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <param name="saveChange">是否执行删除</param>
        /// <returns></returns>
        int Delete(TEntity entity, bool saveChange = true);

        /// <summary>
        /// 删除数据实体集合
        /// </summary>
        /// <param name="entities">数据实体集合</param>
        /// <param name="saveChange">是否执行删除</param>
        /// <returns></returns>
        int Delete(IEnumerable<TEntity> entities, bool saveChange = true);

        /// <summary>
        /// 根据主键删除单个数据实体
        /// </summary>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="key">主键值</param>
        /// <param name="saveChange">是否执行删除</param>
        /// <returns></returns>
        int DeleteById<TKey>(TKey key, bool saveChange = true);

        /// <summary>
        /// 更新单个数据实体
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <param name="saveChange">是否执行更新</param>
        /// <returns></returns>
        int Update(TEntity entity, bool saveChange = true);

        /// <summary>
        /// 更新数据实体集合
        /// </summary>
        /// <param name="entities">数据实体集合</param>
        /// <param name="saveChange">是否执行更新</param>
        /// <returns></returns>
        int Update(IEnumerable<TEntity> entities, bool saveChange = true);

        /// <summary>
        /// 根据主键获取单个数据实体
        /// </summary>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="key">主键值</param>
        /// <returns></returns>
        TEntity GetById<TKey>(TKey key);

        /// <summary>
        /// 记录数
        /// </summary>
        /// <returns></returns>
        int Count();

        /// <summary>
        /// 记录数
        /// </summary>
        /// <param name="predicate">筛选条件</param>
        /// <returns></returns>
        int Count(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        List<TEntity> Query();

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="TKey">排序键</typeparam>
        /// <param name="keySelector">用于从元素中提取键的函数</param>
        /// <param name="orderBy">排序方式（默认 Asc）</param>
        /// <returns></returns>
        List<TEntity> Query<TKey>(Expression<Func<TEntity, TKey>> keySelector, OrderByFlag orderBy);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="orderSelector">排序选择委托</param>
        /// <returns></returns>
        List<TEntity> Query(Func<IQueryable<TEntity>, IQueryable<TEntity>> orderSelector);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="predicate">筛选条件</param>
        /// <returns></returns>
        List<TEntity> Query(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="TKey">排序键</typeparam>
        /// <param name="predicate">筛选条件</param>
        /// <param name="keySelector">用于从元素中提取键的函数</param>
        /// <param name="orderBy">排序方式（默认 Asc）</param>
        /// <returns></returns>
        List<TEntity> Query<TKey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> keySelector, OrderByFlag orderBy);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="predicate">筛选条件</param>
        /// <param name="orderSelector">排序选择委托</param>
        /// <returns></returns>
        List<TEntity> Query(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderSelector);

        /// <summary>
        /// 查询分页
        /// </summary>
        /// <param name="pageNumber">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <returns></returns>
        Pagination<TEntity> QueryPaging(int pageNumber, int pageSize);

        /// <summary>
        /// 查询分页
        /// </summary>
        /// <param name="pageNumber">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="predicate">筛选条件</param>
        /// <returns></returns>
        Pagination<TEntity> QueryPaging(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 查询分页
        /// </summary>
        /// <typeparam name="TKey">排序键</typeparam>
        /// <param name="pageNumber">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="keySelector">用于从元素中提取键的函数</param
        /// <param name="orderBy">排序方式（默认 Asc）</param>
        /// <returns></returns>
        Pagination<TEntity> QueryPaging<TKey>(int pageNumber, int pageSize, Expression<Func<TEntity, TKey>> keySelector, OrderByFlag orderBy);

        /// <summary>
        /// 查询分页
        /// </summary>
        /// <param name="pageNumber">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="orderSelector">排序选择委托</param>
        /// <returns></returns>
        Pagination<TEntity> QueryPaging(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderSelector);

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
        Pagination<TEntity> QueryPaging<TKey>(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> keySelector, OrderByFlag orderBy);

        /// <summary>
        /// 查询分页
        /// </summary>
        /// <param name="pageNumber">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="predicate">筛选条件</param>
        /// <param name="orderSelector">排序选择委托</param>
        /// <returns></returns>
        Pagination<TEntity> QueryPaging(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderSelector);
    }

    /// <summary>
    /// 数据仓储接口
    /// </summary>
    public interface IRepository : IDependency
    {

    }
}
