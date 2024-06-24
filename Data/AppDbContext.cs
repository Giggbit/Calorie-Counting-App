using Microsoft.EntityFrameworkCore;
using CalorieCountingApp.Models;

namespace CalorieCountingApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
        }

        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<AdminData> AdminData { get; set; }
    }
}
