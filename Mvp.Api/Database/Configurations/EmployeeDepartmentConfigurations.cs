using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mvp.Domain.Entities;

namespace Mvp.Api.Database.Configurations
{
    public sealed class EmployeeDepartmentConfigurations : IEntityTypeConfiguration<EmployeeDepartment>
    {
        public void Configure(EntityTypeBuilder<EmployeeDepartment> builder)
        {
            builder.HasKey(ed => new { ed.EmployeeId, ed.DepartmentId });
        }
    }
}
