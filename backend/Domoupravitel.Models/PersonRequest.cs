using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Domoupravitel.Models
{
    public class PersonRequest
    {
        [Required]
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}
