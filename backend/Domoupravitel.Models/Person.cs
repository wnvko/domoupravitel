using System.ComponentModel.DataAnnotations;

namespace Domoupravitel.Models
{
    public class Person
    {
        private ICollection<PersonDescriptor> descriptors = new HashSet<PersonDescriptor>();

        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public bool HasChip { get; set; }

        public DateTime? BirthDate { get; set; }

        public virtual ICollection<PersonDescriptor> Descriptors
        {
            get { return this.descriptors; }
            set { this.descriptors = value; }
        }
    }
}
