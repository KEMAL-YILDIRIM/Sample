using System;

namespace Repository
{
    public interface IUnitOfWork
    {
        void Commit();
        void Dispose();
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
        void Rollback();
    }
}