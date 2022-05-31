using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DDTBaiTapLon486.Models
{
    public partial class BtlDbContext : DbContext
    {
        public BtlDbContext()
            : base("name=BtlDbContext")
        {
        }
        public DbSet<Account> accounts { get; set; }
        public DbSet<KhachHang> khacHangs { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<NhaCungCap> nhaCungCaps { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public System.Data.Entity.DbSet<DDTBaiTapLon486.Models.Category> Categories { get; set; }
    }
}
