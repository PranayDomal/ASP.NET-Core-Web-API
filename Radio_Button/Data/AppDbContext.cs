using Microsoft.EntityFrameworkCore;
using Radio_Button.Models;

namespace Radio_Button.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Student> Student { get; set; }
    }
}
