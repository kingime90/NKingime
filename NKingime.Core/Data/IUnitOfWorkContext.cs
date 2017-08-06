using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKingime.Core.Data
{

    /// <summary>
    /// 工作单元上下文接口
    /// </summary>
    public interface IUnitOfWorkContext : IUnitOfWork
    {
        /// <summary>
        /// 获取数据实体集合
        /// </summary>
        /// <typeparam name="TEntity">数据实体类型</typeparam>
        /// <returns></returns>
        DbSet<TEntity> Set<TEntity>() where TEntity : class, IEntity;

        /// <summary>
        /// 注册新的单个对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity">数据实体类型</typeparam>
        /// <param name="entity">数据实体对象</param>
        void RegisterNew<TEntity>(TEntity entity) where TEntity : class, IEntity;

        /// <summary>
        /// 注册新的数据集合对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity">数据实体类型</typeparam>
        /// <param name="entities">数据集合对象</param>
        void RegisterNew<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IEntity;

        /// <summary>
        /// 注册单个更改的对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity">数据实体对象</param>
        void RegisterModified<TEntity>(TEntity entity) where TEntity : class, IEntity;

        /// <summary>
        /// 注册更改的数据集合对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity">数据实体类型</typeparam>
        /// <param name="entities">数据集合对象</param>
        void RegisterModified<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IEntity;

        /// <summary>
        /// 注册单个删除的对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity">数据实体类型</typeparam>
        /// <param name="entity">数据实体对象</param>
        void RegisterDeleted<TEntity>(TEntity entity) where TEntity : class, IEntity;

        /// <summary>
        /// 注册删除的数据集合对象到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity">数据实体类型</typeparam>
        /// <param name="entities">数据集合对象</param>
        void RegisterDeleted<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IEntity;
    }
}
