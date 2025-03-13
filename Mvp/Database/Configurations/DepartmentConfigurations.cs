using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Mvp.Entities;

namespace Mvp.Database.Configurations
{
    public sealed class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.DepartmentId);
            builder.Property(d => d.Name).HasMaxLength(100);
            builder.HasOne(d => d.Company)
                   .WithMany(c => c.Departments)
                   .HasForeignKey(d => d.CompanyId);
            builder.HasMany(d => d.EmployeeDepartments)
                   .WithOne(ed => ed.Department)
                   .HasForeignKey(ed => ed.DepartmentId);
        }
    }
}
