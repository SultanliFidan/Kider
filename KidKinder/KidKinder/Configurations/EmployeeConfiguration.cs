using KidKinder.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KidKinder.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>

    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(32);
            builder.Property(x => x.Description)
               .IsRequired()
               .HasMaxLength(64);
            builder.Property(x => x.ImageUrl)
               .IsRequired()
               .HasMaxLength(255);
            builder.HasOne(x => x.Department)
                .WithMany(e => e.Employees)
                .HasForeignKey(d => d.DepartmentId);

        }
    }
}
