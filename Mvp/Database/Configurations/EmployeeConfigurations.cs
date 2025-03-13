using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mvp.Entities;

namespace Mvp.Database.Configurations
{
    public sealed class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.EmployeeId);
            builder.Property(e => e.FirstName).HasMaxLength(100);
            builder.Property(e => e.LastName).HasMaxLength(100);
            builder.HasOne(e => e.Manager)
                 .WithMany(e => e.Subordinates)
                 .HasForeignKey(e => e.ManagerId);
            builder.HasMany(e => e.EmployeeDepartments)
                   .WithOne(ed => ed.Employee)
                   .HasForeignKey(ed => ed.EmployeeId);
        }
    }
}
