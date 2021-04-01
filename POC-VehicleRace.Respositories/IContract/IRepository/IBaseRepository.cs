using POC_VehicleRace.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace POC_VehicleRace.Respositories.IContract.IRepository
{
    public interface IBaseRepository<T> where T : class
    {
        EFContext Database { get; }
        void Add(T entity);
        void Delete(Guid entityId);
        IEnumerable<T> FindAll();
    }
}
