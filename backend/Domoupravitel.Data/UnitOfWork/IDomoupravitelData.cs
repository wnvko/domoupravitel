using Domoupravitel.Data.Repositories;
using Domoupravitel.Models;

namespace Domoupravitel.Data.UnitOfWork
{
    public interface IDomoupravitelData
    {
        IGenericRepository<User> Users { get; }

        IGenericRepository<Person> People { get; }

        void SaveChanges();
    }
}
