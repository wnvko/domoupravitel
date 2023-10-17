using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class PersonRequest
    {
        [Required]
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}
