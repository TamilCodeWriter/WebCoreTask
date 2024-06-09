using Microsoft.EntityFrameworkCore;
using WebCoreTask.Models;

namespace WebCoreTask.Data
{
    public class SecondDatabaseContext : DbContext
    {
        public  SecondDatabaseContext (DbContextOptions<SecondDatabaseContext> options) : base(options)
        {

        }
        public DbSet<EmpModel> Employee { get; set; }
    }
}
