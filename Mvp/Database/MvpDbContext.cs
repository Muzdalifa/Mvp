using Microsoft.EntityFrameworkCore;
using Mvp.Entities;

namespace Mvp.Database
{
    public sealed class MvpDbContext(DbContextOptions<MvpDbContext> options):DbContext(options)
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<EmployeeDepartment> EmployeeDepartments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Schema.MVP);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MvpDbContext).Assembly);
        }
    }
}
