using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetByQuery(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAll();
        TEntity GetByID(object id);
        void Insert(TEntity entity);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
    }
}