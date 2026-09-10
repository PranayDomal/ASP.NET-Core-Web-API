using Language_Web_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Language_Web_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Language> Language { get; set; }
    }
}
