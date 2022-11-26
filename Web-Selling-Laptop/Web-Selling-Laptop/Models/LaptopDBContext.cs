using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Web_Selling_Laptop.Models
{
    public partial class LaptopDBContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OrderPro> OrderProes { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public LaptopDBContext()
            : base("name=LaptopDBContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
