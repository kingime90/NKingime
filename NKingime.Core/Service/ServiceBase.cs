using NKingime.Core.Data;

namespace NKingime.Core.Service
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class ServiceBase<TEntity> : IService<TEntity> where TEntity : IEntity
    {

        /// <summary>
        /// 数据实体仓储
        /// </summary>
        protected IRepository<TEntity> EntityRepository { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Save(TEntity entity)
        {
            return EntityRepository.Save(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public TEntity GetById<TKey>(TKey key)
        {
            return EntityRepository.GetById(key);
        }
    }
}
