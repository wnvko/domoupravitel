using System.ComponentModel.DataAnnotations;

namespace Domoupravitel.Models
{
    public class Person
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public PersonDescriptor Descriptor { get; set; }
    }
}
