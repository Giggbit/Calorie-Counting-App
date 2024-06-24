using System.ComponentModel.DataAnnotations;

namespace CalorieCountingApp.Models
{
    public class AdminData
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;
    }
}
