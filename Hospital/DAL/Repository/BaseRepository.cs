using Core.Abstractions.Repository;
using Core.Entities;
using System.Linq;

namespace DAL.Repository
{
    public class BaseRepository<TEntity, TId> : IRepository<TEntity, TId> where TEntity:class, IEntity<TId>
    {
        public BaseRepository(HospitalContext context)
        {
            _context = context;
        }

        protected readonly HospitalContext _context;

        public TEntity Add(TEntity entity)
        {
           _context.Set<TEntity>().Add(entity);
            return entity;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public TEntity GetById(TId id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void RemoveById(TId id)
        {
            Remove(GetById(id));
        }

        public TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return entity;
        }
    }
}
