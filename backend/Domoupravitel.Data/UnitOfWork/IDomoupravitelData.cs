﻿using Domoupravitel.Data.Repositories;
using Domoupravitel.Models;

namespace Domoupravitel.Data.UnitOfWork
{
    public interface IDomoupravitelData
    {
        IGenericRepository<User> Users { get; }

        IGenericRepository<Person> People { get; }

        IGenericRepository<Car> Cars { get; }

        IGenericRepository<Pet> Pets { get; }

        IGenericRepository<Property> Properties { get; }

        IGenericRepository<PersonDescriptor> Descriptors { get; }

        IGenericRepository<Chip> Chips { get; }

        IGenericRepository<GridState> GridStates { get; }

        void SaveChanges();
    }
}
