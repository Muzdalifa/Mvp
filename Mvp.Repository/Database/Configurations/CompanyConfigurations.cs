﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mvp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvp.Repository.Database.Configurations
{
    public sealed class CompanyConfigurations : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(500).IsRequired();
            builder.Property(c => c.Address).HasMaxLength(500).IsRequired();
            builder.Property(c => c.Website).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(500);

            builder.HasMany(c => c.Departments)
                .WithOne(c => c.Company)
                .HasForeignKey(c => c.CompanyId);

            builder.HasMany(c => c.Employees)
                .WithOne(c => c.Company)
                .HasForeignKey(c => c.CompanyId);
        }
    }
}
