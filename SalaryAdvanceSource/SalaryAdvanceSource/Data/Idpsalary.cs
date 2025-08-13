using Microsoft.EntityFrameworkCore;
using SalaryAdvanceSource.Models;

namespace SalaryAdvanceSource.Data
{
    public class Idpsalary : DbContext
    {
        public Idpsalary(DbContextOptions<Idpsalary> options) : base(options) { }

        public DbSet<SalaryAdvanceSource.Models.Users> Users { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Users>()
                .Property(u => u.IsActive)
                .HasConversion<string>();
        }
        public DbSet<SalaryAdvanceSource.Models.Departments> Departments { get; set; } = null!;
        public DbSet<SalaryAdvanceSource.Models.SalaryAdvanceRequests> SalaryAdvanceRequests { get; set; } = null!;
        public DbSet<SalaryAdvanceSource.Models.SalaryLimits> SalaryLimits { get; set; } = null!;
        public DbSet<SalaryAdvanceSource.Models.SalaryLimitDetails> SalaryLimitDetails { get; set; } = null!;
        public DbSet<SalaryAdvanceSource.Models.Information> Information { get; set; } = null!;
    }
}