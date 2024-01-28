using System.ComponentModel.DataAnnotations;

namespace Domoupravitel.Models
{
    public class Chip
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Number { get; set; }

        public bool Disabled { get; set; }

        [Required]
        public Guid PersonId { get; set; }

        public virtual Person Person { get; set; }
    }
}
