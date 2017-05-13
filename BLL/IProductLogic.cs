using System.Collections.Generic;
using BLL.Models;
using ORM;
using Repository;

namespace BLL
{
    public interface IProductLogic
    {
        void Delete(int id);
        Products Find(int id);
        void Insert(ProductViewModel model);
        IEnumerable<ProductViewModel> List();
        IRepository<Products> ProductRepository();
        Products ToEntity(ProductViewModel model);
        ProductViewModel ToModel(Products data);
        void Update(ProductViewModel model);
    }
}