using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mvp.Entities;

namespace Mvp.Database.Configurations
{
    public class CompanyConfigurations : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c => c.CompanyId);
            builder.Property(c => c.Name).HasMaxLength(100);
            builder.Property(c => c.Website).HasMaxLength(100);
            builder.HasMany(c => c.Departments)
                   .WithOne(d => d.Company)
                   .HasForeignKey(d => d.CompanyId)
                   .OnDelete(DeleteBehavior.NoAction); ;

            builder.Ignore(c => c.Location);
        }
    }
}
