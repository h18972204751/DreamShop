using Microsoft.EntityFrameworkCore;
using Orders.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.API.Data
{
    public class OrdersDbContext : DbContext
    {

        public OrdersDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Model.Orders> Orders { get; set; }
        public DbSet<OrdersInfo> OrdersInfo { get; set; }
        

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
            modelBuilder.Entity<Model.Orders>().ToTable("Orders");
            modelBuilder.Entity<OrdersInfo>().ToTable("OrdersInfo");
            
        }




    }


}
