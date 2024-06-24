using System.ComponentModel.DataAnnotations;

namespace CalorieCountingApp.Models
{
    public class Admin
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
