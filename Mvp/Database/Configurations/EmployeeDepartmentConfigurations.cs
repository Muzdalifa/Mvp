using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mvp.Entities;

namespace Mvp.Database.Configurations
{
    public class EmployeeDepartmentConfigurations : IEntityTypeConfiguration<EmployeeDepartment>
    {
        public void Configure(EntityTypeBuilder<EmployeeDepartment> builder)
        {
            builder.HasKey(ed => new { ed.EmployeeId, ed.DepartmentId });

            builder.HasOne(ed => ed.Employee)
                   .WithMany(e => e.EmployeeDepartments)
                   .HasForeignKey(ed => ed.EmployeeId);

            builder.HasOne(ed => ed.Department)
                   .WithMany(d => d.EmployeeDepartments)
                   .HasForeignKey(ed => ed.DepartmentId);
        }
    }
}
