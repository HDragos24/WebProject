using Microsoft.EntityFrameworkCore;
using WebProject.Model;

namespace WebProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Category> Category { get; set; }
    }
}
