using System.ComponentModel.DataAnnotations;

namespace Domoupravitel.Models
{
    public class RegistrationRequest
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
