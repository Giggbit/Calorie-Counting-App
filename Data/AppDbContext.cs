using CalorieCountingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CalorieCountingApp.Data
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {    
        }

        public DbSet<FoodItem> FoodItems { get; set; }
    }
}
