using Microsoft.EntityFrameworkCore;
using WebCoreTask.Models;

namespace WebCoreTask.Data
{
    public class ApplicationDbContext : DbContext
    {
      
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }

            public DbSet<User> Users { get; set; }
           // public DbSet<Employee> Employees { get; set; }

            public DbSet<Employee> Employees { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Map the model to the existing table
            modelBuilder.Entity<Employee>().ToTable("Employees");
        }
    }
}
