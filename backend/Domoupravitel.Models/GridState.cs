using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Domoupravitel.Models
{
    [Index(nameof(GridName))]
    public class GridState
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(200)]
        public string GridName { get; set; }

        [Required]
        public string Options { get; set; }
    }
}
