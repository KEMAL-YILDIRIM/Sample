using DryIoc;
using ORM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        internal readonly DbContext context;

        public UnitOfWork(DbContext _context)
        {
            context = _context;
        }


        //private GenericRepository<Products> productRepository;

        ////Accessors for each private repository, creates repository if null
        //public IRepository<Products> ProductRepository
        //{
        //    get
        //    {
        //        if (productRepository == null)
        //        {
        //            productRepository = new GenericRepository<Products>(context);
        //        }
        //        return productRepository;
        //    }

        //}

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            using (var container = new Container())
            {
                var _repository = container.Resolve<IRepository<TEntity>>();
                return _repository;
            }
        }

        public void Commit()
        {
            context.SaveChanges();
        }


        public void Rollback()
        {
            context
                .ChangeTracker
                .Entries()
                .ToList()
                .ForEach(x => x.Reload());
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
