using NKingime.Entity;
using System.Data.Entity;

namespace NKingime.DataAccess.DbContext
{
    /// <summary>
    /// 
    /// </summary>
    public class NKingimeDb : System.Data.Entity.DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public NKingimeDb()
            : base("name=NKingimeDb")
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nameOrConnectionString"></param>
        public NKingimeDb(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User").HasKey(m => m.Id);
            modelBuilder.Entity<Module>().ToTable("Module").HasKey(m => m.Id);
            modelBuilder.Entity<Role>().ToTable("Role").HasKey(m => m.Id);
        }
    }
}
