using ExcelToDatabaseAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ExcelToDatabaseAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<customer> Customers { get; set; }
        public DbSet<tab> Tab { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
