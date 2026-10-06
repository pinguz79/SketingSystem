using DataModel.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Repositories
{
    public class BaseRepository<TEntity>(DataModelContext context) : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly DataModelContext _context = context;
        private readonly DbSet<TEntity> _set = context.Set<TEntity>();

        public TEntity Add(TEntity entity) => _set.Add(entity).Entity;
        public IQueryable<TEntity> GetAll() => _set.AsQueryable();

        public TEntity GetById(Guid id) => _set.Find(id);

        public void Delete(Guid id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _set.Remove(entity);
            }
        }

        public IQueryable<TEntity> Where(Func<TEntity, bool> predicate) => _set.Where(predicate).AsQueryable();
    }
}
