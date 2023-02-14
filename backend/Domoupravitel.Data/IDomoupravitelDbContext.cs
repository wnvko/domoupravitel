using Microsoft.EntityFrameworkCore;
using Domoupravitel.Models;
using Microsoft.AspNetCore.Identity;

namespace Domoupravitel.Data
{
    public interface IDomoupravitelDbContext
    {
        DbSet<IdentityUser> Users { get; set; }

        DbSet<T> Set<T>() where T : class;

        void SaveChanges();
    }
}
