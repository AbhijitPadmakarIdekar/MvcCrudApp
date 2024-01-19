using Microsoft.EntityFrameworkCore;
using MvcCrudApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcCrudApp.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
                public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<User>().HasData(
                new User { UserID = 1, UserName = "Abhijit", Password = "12345", EmailAddress = "AbhjitIdekar@gmail.com" },
                new User { UserID = 2, UserName = "Ramesh", Password = "123xyz", EmailAddress = "RameshMali@gmail.com" },
                new User { UserID = 3, UserName = "Akshay", Password = "Jadhav1", EmailAddress = "AkshayJadhav@gmail.com" });
        }
    }
}
