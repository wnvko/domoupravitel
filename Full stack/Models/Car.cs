using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Car
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Number { get; set; }

        public string Brand { get; set; }

        public string Color { get; set; }

        public Guid? PropertyId { get; set; }

        public virtual Property Property { get; set; }
    }
}
