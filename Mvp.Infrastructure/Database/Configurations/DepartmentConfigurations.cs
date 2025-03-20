using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mvp.Domain.Entities;

namespace Mvp.Api.Database.Configurations
{
    public sealed class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(d => d.Name).HasMaxLength(500).IsRequired();
            builder.Property(d => d.Location).HasMaxLength(500).IsRequired();
            builder.Property(d => d.Description).HasMaxLength(500);

            builder.HasMany(d => d.EmployeeDepartments)
                .WithOne(d => d.Department)
                .HasForeignKey(d => d.DepartmentId);
        }
    }
}
