using Microsoft.EntityFrameworkCore;

namespace RestApiMysqlSdk9.ModelsBase
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Ent_user> Ent_user { get; set; }
    }
}
