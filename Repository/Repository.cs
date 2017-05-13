using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal DbContext context;
        internal DbSet<TEntity> dbSet;

        public Repository(DbContext _context)
        {
            this.context = _context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetByQuery(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            if (context.Entry(entityToUpdate).State == EntityState.Detached)
            {
                dbSet.Attach(entityToUpdate);
            }
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }

}
