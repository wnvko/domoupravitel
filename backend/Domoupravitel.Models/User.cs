using Microsoft.AspNetCore.Identity;

namespace Domoupravitel.Models
{
    public class User: IdentityUser
    {
        public string Name { get; set; }
    }
}
