using System.ComponentModel.DataAnnotations;
using Models.Enums;

namespace Models
{
    public class Property
    {
        private ICollection<PersonDescriptor> people = new HashSet<PersonDescriptor>();
        private ICollection<Pet> pets = new HashSet<Pet>();
        private ICollection<Car> cars = new HashSet<Car>();

        [Required]
        public Guid Id { get; set; }

        [Required]
        public PropertyType Type { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public double Share { get; set; }

        public virtual ICollection<PersonDescriptor> People
        {
            get { return this.people; }
            set { this.people = value; }
        }

        public virtual ICollection<Pet> Pets
        {
            get { return this.pets; }
            set { this.pets = value; }
        }

        public virtual ICollection<Car> Cars
        {
            get { return this.cars; }
            set { this.cars = value; }
        }
    }
}
