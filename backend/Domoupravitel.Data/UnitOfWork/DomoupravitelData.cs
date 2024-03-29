﻿using Domoupravitel.Data.Repositories;
using Domoupravitel.Models;

namespace Domoupravitel.Data.UnitOfWork
{
    public class DomoupravitelData : IDomoupravitelData
    {
        private IDomoupravitelDbContext _context;
        private IDictionary<Type, object> _repositories;

        public DomoupravitelData(IDomoupravitelDbContext context)
        {
            this._context = context;
            this._repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<User> Users => this.GetRepository<User>();

        public IGenericRepository<Person> People => this.GetRepository<Person>();

        public IGenericRepository<Car> Cars => this.GetRepository<Car>();

        public IGenericRepository<Pet> Pets => this.GetRepository<Pet>();

        public IGenericRepository<Property> Properties => this.GetRepository<Property>();

        public IGenericRepository<PersonDescriptor> Descriptors => this.GetRepository<PersonDescriptor>();

        public IGenericRepository<Chip> Chips => this.GetRepository<Chip>();

        public IGenericRepository<GridState> GridStates => this.GetRepository<GridState>();

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this._repositories.ContainsKey(typeOfModel))
            {
                var typeOfRepository = typeof(GenericRepository<T>);

                this._repositories.Add(typeOfModel, Activator.CreateInstance(typeOfRepository, this._context));
            }

            return (IGenericRepository<T>)this._repositories[typeOfModel];
        }
    }
}
