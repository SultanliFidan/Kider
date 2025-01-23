using KidKinder.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KidKinder.Context
{
    public class KidkinderDbContext : IdentityDbContext<User>
    {
        public KidkinderDbContext(DbContextOptions opt) : base(opt)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(KidkinderDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
