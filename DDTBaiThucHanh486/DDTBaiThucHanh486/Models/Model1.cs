using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DDTBaiThucHanh486.Models
{
    public partial class Model1
        : DbContext
    {
        public Model1()
            : base("name=LTQLdbcontext")
        {
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
