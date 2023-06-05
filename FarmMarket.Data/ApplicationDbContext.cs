using FarmMarket.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace FarmMarket.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<FarmProduct> FarmProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}