using Microsoft.EntityFrameworkCore;
using Domoupravitel.Models;

namespace Domoupravitel.Data
{
    public interface IDomoupravitelDbContext
    {
        DbSet<User> Users { get; set; }

        DbSet<Person> People { get; set; }

        DbSet<Car> Cars { get; set; }

        DbSet<Pet> Pets { get; set; }

        DbSet<Property> Properties { get; set; }

        DbSet<PersonDescriptor> Descriptors { get; set; }

        DbSet<T> Set<T>() where T : class;

        void SaveChanges();
    }
}
