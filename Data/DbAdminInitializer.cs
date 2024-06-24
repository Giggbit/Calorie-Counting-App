using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Security.Cryptography;
using CalorieCountingApp.Models;

namespace CalorieCountingApp.Data
{
    public class DbAdminInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider) {
            using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>())) {
                context.Database.Migrate();

                if (!context.AdminData.Any()) {
                    var adminUser = new AdminData {
                        Username = "admin",
                        PasswordHash = HashPassword("password")
                    };

                    context.AdminData.Add(adminUser);
                    context.SaveChanges();
                }
            }
        }

        private static string HashPassword(string password) {
            using (var sha256 = SHA256.Create()) {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}
