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
        public virtual DbSet<User> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
