using System.ComponentModel.DataAnnotations;
using Models.Enums;

namespace Models
{
    public class RegistrationRequest
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        public Role? Role { get; set; } = null!;
    }
}
