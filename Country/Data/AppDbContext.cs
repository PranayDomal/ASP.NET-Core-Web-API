using Country_webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace Country_webapi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Country> Country { get; set; }
    }
}
