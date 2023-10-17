using Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace Models
{
    public class User: IdentityUser
    {
        public string Name { get; set; }

        public Role Role { get; set; }
    }
}
