using NKingime.Core.Data;
using NKingime.Core.Define;
using NKingime.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
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
        /// 记录数
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return EntityRepository.Count();
        }

        /// <summary>
        /// 记录数
        /// </summary>
        /// <param name="predicate">筛选条件</param>
        /// <returns></returns>
        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return EntityRepository.Count(predicate);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public List<TEntity> Query()
        {
            return EntityRepository.Query();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="TKey">排序键</typeparam>
        /// <param name="keySelector">用于从元素中提取键的函数</param>
        /// <param name="orderBy">排序方式（默认 Asc）</param>
        /// <returns></returns>
        public List<TEntity> Query<TKey>(Expression<Func<TEntity, TKey>> keySelector, OrderBy orderBy = OrderBy.Asc)
        {
            return EntityRepository.Query(keySelector, orderBy);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="orderSelector">排序选择委托</param>
        /// <returns></returns>
        public List<TEntity> Query(Func<IQueryable<TEntity>, IQueryable<TEntity>> orderSelector)
        {
            return EntityRepository.Query(orderSelector);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="predicate">筛选条件</param>
        /// <returns></returns>
        public List<TEntity> Query(Expression<Func<TEntity, bool>> predicate)
        {
            return EntityRepository.Query(predicate);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="TKey">排序键</typeparam>
        /// <param name="predicate">筛选条件</param>
        /// <param name="keySelector">用于从元素中提取键的函数</param>
        /// <param name="orderBy">排序方式（默认 Asc）</param>
        /// <returns></returns>
        public List<TEntity> Query<TKey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> keySelector, OrderBy orderBy = OrderBy.Asc)
        {
            return EntityRepository.Query(predicate, keySelector, orderBy);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="predicate">筛选条件</param>
        /// <param name="orderSelector">排序选择委托</param>
        /// <returns></returns>
        public List<TEntity> Query(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderSelector)
        {
            return EntityRepository.Query(predicate, orderSelector);
        }

        /// <summary>
        /// 查询分页
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <returns></returns>
        public Pagination<TEntity> QueryPaging(int pageIndex, int pageSize)
        {
            return EntityRepository.QueryPaging(pageIndex, pageSize);
        }

        /// <summary>
        /// 查询分页
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="predicate">筛选条件</param>
        /// <returns></returns>
        public Pagination<TEntity> QueryPaging(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> predicate)
        {
            return EntityRepository.QueryPaging(pageIndex, pageSize, predicate);
        }

        /// <summary>
        /// 查询分页
        /// </summary>
        /// <typeparam name="TKey">排序键</typeparam>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="keySelector">用于从元素中提取键的函数</param
        /// <param name="orderBy">排序方式（默认 Asc）</param>
        /// <returns></returns>
        public Pagination<TEntity> QueryPaging<TKey>(int pageIndex, int pageSize, Expression<Func<TEntity, TKey>> keySelector, OrderBy orderBy = OrderBy.Asc)
        {
            return EntityRepository.QueryPaging(pageIndex, pageSize, keySelector, orderBy);
        }

        /// <summary>
        /// 查询分页
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="orderSelector">排序选择委托</param>
        /// <returns></returns>
        public Pagination<TEntity> QueryPaging(int pageIndex, int pageSize, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderSelector)
        {
            return EntityRepository.QueryPaging(pageIndex, pageSize, orderSelector);
        }

        /// <summary>
        /// 查询分页
        /// </summary>
        /// <typeparam name="TKey">排序键</typeparam>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="predicate">筛选条件</param>
        /// <param name="keySelector">用于从元素中提取键的函数</param
        /// <param name="orderBy">排序方式（默认 Asc）</param>
        /// <returns></returns>
        public Pagination<TEntity> QueryPaging<TKey>(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> keySelector, OrderBy orderBy = OrderBy.Asc)
        {
            return EntityRepository.QueryPaging(pageIndex, pageSize, predicate, keySelector, orderBy);
        }

        /// <summary>
        /// 查询分页
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="predicate">筛选条件</param>
        /// <param name="orderSelector">排序选择委托</param>
        /// <returns></returns>
        public Pagination<TEntity> QueryPaging(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderSelector)
        {
            return EntityRepository.QueryPaging(pageIndex, pageSize, predicate, orderSelector);
        }
    }
}
