using Microsoft.EntityFrameworkCore;
using Mvp.Api.Database.Extensions;
using Mvp.Domain.Entities;

namespace Mvp.Api.Database
{
    public sealed class MvpDbContext(DbContextOptions<MvpDbContext> options): DbContext(options)
    {
        public DbSet<Company> Companies { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeDepartment> EmployeeDepartments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Schema.MVP);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MvpDbContext).Assembly);
            modelBuilder.SeedData();
        }
    }
}
