using AddWords.Model;
using Microsoft.EntityFrameworkCore;

namespace AddWords.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Words> Words { get; set; }

    }
}
