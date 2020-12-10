using Microsoft.EntityFrameworkCore;
using Product.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Data
{
    public class ProductDbContext : DbContext
    {

        public ProductDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Products> Products { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<ProductProperties> ProductProperties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Orders>().HasData(
            //    new Orders
            //    {
            //        Id = Guid.NewGuid().ToString(),
            //        LoginName = "admin",
            //        LoginPassword = "123",
            //        Status = UserStatus.Normal,
            //        CreateTime = DateTime.Now,
            //    },
            //    new Orders
            //    {
            //        Id = Guid.NewGuid().ToString(),
            //        LoginName = "wmh",
            //        LoginPassword = "123456",
            //        Status = UserStatus.Normal,
            //        CreateTime = DateTime.Now,
            //    }
            //    );
            modelBuilder.Entity<Products>().ToTable("Products");
            modelBuilder.Entity<ProductType>().ToTable("ProductType");
            modelBuilder.Entity<ProductProperties>().ToTable("ProductProperties");
        }




    }


}
