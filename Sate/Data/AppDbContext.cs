using Microsoft.EntityFrameworkCore;
using Sate_webapi.Models;

namespace Sate_webapi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<State> State { get; set; }
    }
}
