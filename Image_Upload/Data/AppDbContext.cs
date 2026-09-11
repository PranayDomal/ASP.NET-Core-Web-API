using Image_Upload.Models;
using Microsoft.EntityFrameworkCore;

namespace Image_Upload.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Customer> Customer { get; set; }
    }
}
