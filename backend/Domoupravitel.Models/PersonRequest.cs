using System.ComponentModel.DataAnnotations;

namespace Domoupravitel.Models
{
    public class PersonRequest
    {
        [Required]
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public bool HasChip { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}
