using Core8_EF_PostgresSql.Models;
using Microsoft.EntityFrameworkCore;

namespace Core8_EF_PostgresSql.DbContexts
{  
    public class ApplicationDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        }

       public DbSet<Student> student { get; set; }       

    }
}
