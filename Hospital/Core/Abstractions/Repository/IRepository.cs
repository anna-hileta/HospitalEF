using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Abstractions.Repository
{
    public interface IRepository<TEntity, TId>
    {
        TEntity GetById(TId id);
        IQueryable<TEntity> GetAll();
        TEntity Add(TEntity entity);
        void Remove(TEntity entity);
        void RemoveById(TId id);
        TEntity Update(TEntity entity);
    }
}
