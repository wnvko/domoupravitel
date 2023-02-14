using Domoupravitel.Data.Repositories;
using Domoupravitel.Models;
using Microsoft.AspNetCore.Identity;

namespace Domoupravitel.Data.UnitOfWork
{
    public interface IDomoupravitelData
    {
        IGenericRepository<IdentityUser> Users { get; }

        void SaveChanges();
    }
}
