using KidKinder.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KidKinder.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(32);
            builder.HasMany(x => x.Employees)
                .WithOne(d => d.Department);
        }
    }
}
