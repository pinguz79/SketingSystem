using DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);
        IQueryable<TEntity> GetAll();
        TEntity GetById(Guid id);
        void Delete(Guid id);
        IQueryable<TEntity> Where(Func<TEntity, bool> predicate);
    }
}
