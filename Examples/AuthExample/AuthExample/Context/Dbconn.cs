using Microsoft.EntityFrameworkCore;
namespace AuthExample.AooDbContext
{
    public class AppDbcontext : DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options)
        {
           
        }
        public DbSet<AuthExample.Models.User> Users { get; set; }
    }
}
