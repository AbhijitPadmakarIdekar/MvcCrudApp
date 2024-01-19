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

            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 105,
                UserName = "Acc0185",
                Role = "A/C Mgr",
                LastLogin = DateTime.Parse("2020-08-23 14:25:34"),
                FName = "Sanjay",
                LName = "Agarwal",
                Department = "Accounts",
                DOJ = DateTime.Parse("2018-05-20"),
                MgrId = 78,
                Seniority = 5.08m,
                EmpCode = "ACC0034"
            },
    new User
    {
        UserId = 106,
        UserName = "Acc0567",
        Role = "Asst.",
        FName = "Amit",
        LName = "Sharma",
        Department = "Accounts",
        DOJ = DateTime.Parse("2020-09-16"),
        MgrId = 105,
        Seniority = 8.15m,
        EmpCode = "ACC0598"
    },
    new User
    {
        UserId = 428,
        UserName = "Dev0476",
        Role = "VP",
        LastLogin = DateTime.Parse("2020-09-19 10:45:12"),
        FName = "Lokesh",
        LName = "Kumar",
        Department = "Development",
        DOJ = DateTime.Parse("2018-22-12"),
        Seniority = 1.05m,
        EmpCode = "DEV0833"
    },
    new User
    {
        UserId = 568,
        UserName = "ADM6633",
        Role = "Exec",
        DOJ = DateTime.Parse("2011-06-06"),
        Seniority = 9.01m,
        EmpCode = "ADM0048"
    });
        }
    }
}
