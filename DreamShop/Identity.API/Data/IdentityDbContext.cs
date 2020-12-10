using Identity.API.Enums;
using Identity.API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Data
{
    public class IdentityDbContext: DbContext
    {

        public IdentityDbContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Roles> Roles { get; set; }
        public DbSet<Logins> Logins { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Logins>().HasData(
            //    new Logins
            //    {
            //        LoginName="admin",
            //        LoginPassword="123",
            //        Status= UserStatus.Normal,
            //        CreateTime=DateTime.Now,
            //    },
            //    new Logins
            //    {
            //        LoginName = "wmh",
            //        LoginPassword = "123456",
            //        Status = UserStatus.Normal,
            //        CreateTime = DateTime.Now,
            //    }
            //    ) ;
            modelBuilder.Entity<Roles>().ToTable("Roles");
            modelBuilder.Entity<Logins>().ToTable("Logins");
            modelBuilder.Entity<UserRoles>().ToTable("UserRoles");
            modelBuilder.Entity<Users>().ToTable("Users");
        }




    }
}
