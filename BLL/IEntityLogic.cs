using System.Collections.Generic;
using BLL.Models;
using ORM;
using Repository;

namespace BLL
{
    public interface IEntityLogic<TEntity , TViewModel>
        where TViewModel : class
        where TEntity : class
    {
        void Delete(int id);
        TEntity Find(int id);
        void Insert(TViewModel model);
        IEnumerable<TViewModel> List();
        IRepository<TEntity> ProductRepository();
        TEntity ToEntity(TViewModel model);
        TViewModel ToModel(TEntity data);
        void Update(TViewModel model);
    }
}