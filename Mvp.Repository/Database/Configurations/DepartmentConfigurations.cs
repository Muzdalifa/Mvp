using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mvp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvp.Repository.Database.Configurations
{
    class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Name).HasMaxLength(500).IsRequired();
            builder.Property(d => d.Location).HasMaxLength(500).IsRequired();
            builder.Property(d => d.Description).HasMaxLength(500);

            builder.HasMany(d => d.EmployeeDepartmens)
                .WithOne(d => d.Department)
                .HasForeignKey(d => d.DepartmentId);
        }
    }
}
