using System.ComponentModel.DataAnnotations;
using Models.Enums;

namespace Models
{
    public class PersonDescriptor
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid PersonId { get; set; }

        public virtual Person Person { get; set; }

        [Required]
        public Guid PropertyId { get; set; }

        public virtual Property Property { get; set; }

        [Required]
        public PersonType Type { get; set; }

        [Required]
        public Residence Residence { get; set; }

        public int MonthsInHouse { get; set; } = 12;

        public DateTime? RegisteredOn { get; set; }

        public DateTime? UnRegisteredOn { get; set; }
    }
}
