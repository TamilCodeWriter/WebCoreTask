using Microsoft.EntityFrameworkCore;
using WebCoreTask.Models;

namespace WebCoreTask.Data
{
    public class FirstDataBaseContext : DbContext
    {


        public FirstDataBaseContext(DbContextOptions<FirstDataBaseContext> options) : base(options)
        {
        }

        public DbSet<EmpModel> Employee { get; set; }
    }

}
