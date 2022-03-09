using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DDTBaiTapLon486.Models
{
    public partial class BTLDbcontext : DbContext
    {
        public BTLDbcontext()
            : base("name=BTLDbcontext")
        {
        }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
