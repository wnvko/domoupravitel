using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Domoupravitel.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private IDomoupravitelDbContext _context;
        private DbSet<T> _set;

        public GenericRepository(IDomoupravitelDbContext context)
        {
            this._context = context;
            this._set = context.Set<T>();
        }

        public IQueryable<T> All()
        {
            return this._set.AsQueryable();
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> conditions)
        {
            return this.All().Where(conditions);
        }

        public void Add(T entity)
        {
            var entry = this.AttachIfDetached(entity);
            entry.State = EntityState.Added;
        }

        public void Update(T entity)
        {
            var entry = this.AttachIfDetached(entity);
            entry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            var entry = this.AttachIfDetached(entity);
            entry.State = EntityState.Deleted;
        }

        public void Detach(T entity)
        {
            var entry = this.AttachIfDetached(entity);
            entry.State = EntityState.Detached;
        }

        private EntityEntry AttachIfDetached(T entity)
        {
            var entry = this._set.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this._set.Attach(entity);
            }

            return entry;
        }
    }
}
