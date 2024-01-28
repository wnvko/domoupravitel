using System.ComponentModel.DataAnnotations;

namespace Domoupravitel.Models
{
    public class Person
    {
        private ICollection<PersonDescriptor> descriptors = new HashSet<PersonDescriptor>();
        private ICollection<Chip> chips = new HashSet<Chip>();

        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public DateTime? BirthDate { get; set; }

        public virtual ICollection<PersonDescriptor> Descriptors
        {
            get { return this.descriptors; }
            set { this.descriptors = value; }
        }

        public virtual ICollection<Chip> Chips
        {
            get { return this.chips; }
            set { this.chips = value; }
        }
    }
}
