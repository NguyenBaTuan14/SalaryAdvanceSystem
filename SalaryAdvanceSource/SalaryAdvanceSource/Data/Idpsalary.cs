using Microsoft.EntityFrameworkCore;
using SalaryAdvanceSource.Models;

namespace SalaryAdvanceSource.Data
{
    public class Idpsalary : DbContext
    {
        public Idpsalary(DbContextOptions<Idpsalary> options) : base(options) { }

        public DbSet<SalaryAdvanceSource.Models.Users> Users { get; set; } = null!;
        public DbSet<SalaryAdvanceSource.Models.Departments> Departments { get; set; } = null!;
        public DbSet<SalaryAdvanceSource.Models.SalaryAdvanceRequests> SalaryAdvanceRequests { get; set; } = null!;
    }
}