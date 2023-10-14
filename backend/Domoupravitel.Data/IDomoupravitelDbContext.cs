using Microsoft.EntityFrameworkCore;
using Domoupravitel.Models;

namespace Domoupravitel.Data
{
    public interface IDomoupravitelDbContext
    {
        DbSet<User> Users { get; set; }

        DbSet<Person> People { get; set; }

        DbSet<T> Set<T>() where T : class;

        void SaveChanges();
    }
}
