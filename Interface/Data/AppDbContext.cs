using District_webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace District_webapi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<District> District { get; set; }
    }
}
