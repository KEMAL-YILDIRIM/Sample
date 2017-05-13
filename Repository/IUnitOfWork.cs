using ORM;
using System;

namespace Repository
{
    public interface IUnitOfWork
    {
        void Commit();
        void Dispose();
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        void Rollback();
    }
}