using NKingime.Entity.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

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
        }

        public virtual DbSet<User> Users { get; set; }

    }
}
