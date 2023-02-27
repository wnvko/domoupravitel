using System.ComponentModel.DataAnnotations;

namespace Domoupravitel.Models
{
    public class UpdateRequest
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        public string NewPassword { get; set; } = null!;

        [Required]
        public string RepeatPassword { get; set; } = null!;
    }
}
