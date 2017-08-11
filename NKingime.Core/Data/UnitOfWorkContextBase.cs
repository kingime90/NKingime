using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKingime.Core.Data
{
    /// <summary>
    /// 工作单元上下文基类
    /// </summary>
    public abstract class UnitOfWorkContextBase : IUnitOfWorkContext
    {

        /// <summary>
        /// 数据库上下文
        /// </summary>
        public abstract DbContext DbContext { get; }

        private bool _isCommitted = false;

        /// <summary>
        /// 工作单元是否已被提交
        /// </summary>
        public bool IsCommitted
        {
            get
            {
                return _isCommitted;
            }
        }

        /// <summary>
        /// 提交工作单元
        /// </summary>
        /// <returns></returns>
        public int Commit()
        {
            if (IsCommitted)
            {
                return 0;
            }
            //
            int result = DbContext.SaveChanges();
            _isCommitted = true;
            return result;
        }

        /// <summary>
        /// 回滚工作单元到未提交
        /// </summary>
        public void Rollback()
        {
            _isCommitted = false;
        }

        /// <summary>
        /// 注册删除的数据实体集合到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity">数据实体类型</typeparam>
        /// <param name="entities">数据实体集合</param>
        public void RegisterDeleted<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IEntity
        {
            try
            {
                SetAutoDetectChangesEnabled(false);
                foreach (TEntity entity in entities)
                {
                    RegisterDeleted(entity);
                }
            }
            finally
            {
                SetAutoDetectChangesEnabled(true);
            }
        }

        /// <summary>
        /// 注册单个删除的数据实体到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity">数据实体类型</typeparam>
        /// <param name="entity">数据实体</param>
        public void RegisterDeleted<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            Entry(entity).State = EntityState.Deleted;
            _isCommitted = false;
        }

        /// <summary>
        /// 注册更改的数据实体集合到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity">数据实体类型</typeparam>
        /// <param name="entities">数据实体集合</param>
        public void RegisterModified<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IEntity
        {
            try
            {
                SetAutoDetectChangesEnabled(false);
                foreach (TEntity entity in entities)
                {
                    RegisterModified(entity);
                }
            }
            finally
            {
                SetAutoDetectChangesEnabled(true);
            }
        }

        /// <summary>
        /// 注册单个更改的数据实体到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity">数据实体类型</typeparam>
        /// <param name="entity">数据实体</param>
        public void RegisterModified<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            var entityEntry = Entry(entity);
            if (entityEntry.State == EntityState.Detached)
            {
                DbContext.Set<TEntity>().Attach(entity);
            }
            entityEntry.State = EntityState.Modified;
            _isCommitted = false;
        }

        /// <summary>
        /// 注册新的数据实体集合到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity">数据实体类型</typeparam>
        /// <param name="entities">数据实体集合</param>
        public void RegisterNew<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IEntity
        {
            try
            {
                SetAutoDetectChangesEnabled(false);
                foreach (TEntity entity in entities)
                {
                    RegisterNew(entity);
                }
            }
            finally
            {
                SetAutoDetectChangesEnabled(true);
            }
        }

        /// <summary>
        /// 注册新的单个数据实体到仓储上下文中
        /// </summary>
        /// <typeparam name="TEntity">数据实体类型</typeparam>
        /// <param name="entity">数据实体</param>
        public void RegisterNew<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            var entityEntry = Entry(entity);
            if (entityEntry.State == EntityState.Detached)
            {
                entityEntry.State = EntityState.Added;
            }
            _isCommitted = false;
        }

        /// <summary>
        /// 获取数据实体集合
        /// </summary>
        /// <typeparam name="TEntity">数据实体类型</typeparam>
        /// <returns></returns>
        public DbSet<TEntity> Set<TEntity>() where TEntity : class, IEntity
        {
            return DbContext.Set<TEntity>();
        }

        /// <summary>
        /// 获取给定实体的 System.Data.Entity.Infrastructure.DbEntityEntry`1 对象，以便提供对与该实体有关的信息的访问以及对实体执行操作的功能
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            return DbContext.Entry(entity);
        }

        /// <summary>
        /// 获取或设置一个值，该值指示是否通过 System.Data.Entity.DbContext 和相关类的方法自动调用 System.Data.Entity.Infrastructure.DbChangeTracker.DetectChanges 方法。默认值为 true。
        /// </summary>
        /// <param name="autoDetectChangesEnabled"></param>
        protected void SetAutoDetectChangesEnabled(bool autoDetectChangesEnabled = true)
        {
            DbContext.Configuration.AutoDetectChangesEnabled = autoDetectChangesEnabled;
        }

        /// <summary>
        /// 执行与释放或重置非托管资源关联的应用程序定义的任务
        /// </summary>
        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
