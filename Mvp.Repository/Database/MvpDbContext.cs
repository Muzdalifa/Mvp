using Microsoft.EntityFrameworkCore;
using Mvp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvp.Repository.Database;

public sealed class MvpDbContext(DbContextOptions<MvpDbContext> options):DbContext(options)
{
    public DbSet<Company> Companies { get; set; }

    public DbSet<Department> Departments { get; set; }

    public DbSet<Employee> Employee { get; set; }

    public DbSet<EmployeeDepartment> EmployeeDepartments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schema.MVP);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MvpDbContext).Assembly);
    }
}
