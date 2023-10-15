using System.ComponentModel.DataAnnotations;

namespace Domoupravitel.Models
{
    public class Pet
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Number { get; set; }

        public string Name { get; set; }

        public Guid PropertyId { get; set; }

        public virtual Property Property { get; set; }
    }
}
