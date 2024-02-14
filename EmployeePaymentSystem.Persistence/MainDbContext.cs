using EmployeePaymentSystem.Common.Enums;
using EmployeePaymentSystem.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePaymentSystem.Persistence
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options)
        : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Season> Seasons { get; set; }

        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().Property(p => p.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<Season>().Property(p => p.IsDeleted).HasDefaultValue(false);
            modelBuilder.Entity<Payment>().Property(p => p.IsDeleted).HasDefaultValue(false);

            modelBuilder.Entity<Payment>().Property(p => p.PaymentType).HasDefaultValue(PaymentType.None);

            modelBuilder.Entity<Payment>().HasOne(p => p.Employee).WithMany(p => p.Payments).HasForeignKey(p => p.EmployeeId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Payment>().HasOne(p => p.Season).WithMany(p => p.Payments).HasForeignKey(p => p.SeasonId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
