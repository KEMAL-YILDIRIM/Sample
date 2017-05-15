using BLL.Models;
using ORM;
using Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProductLogic : IProductLogic
    {

        private IUnitOfWork UnitOfWork;

        public ProductLogic(IUnitOfWork _UoW)
        {
            UnitOfWork = _UoW;
        }

        public virtual IRepository<Products> ProductRepository()
        {
            var prdct = UnitOfWork.GetRepository<Products>();
            return prdct;
        }

        public virtual ProductViewModel ToModel(Products data)
        {
            ProductViewModel product = new ProductViewModel();
            product.Name = data.ProductName;
            product.Stock = data.UnitsInStock;
            product.Price = data.UnitPrice;
            return product;
        }

        public virtual Products ToEntity(ProductViewModel model)
        {
            Products prdct = new Products();
            prdct.ProductName = model.Name;
            prdct.UnitsInStock = model.Stock;
            prdct.UnitPrice = model.Price;
            return prdct;
        }

        public virtual IEnumerable<ProductViewModel> List()
        {
            var data = ProductRepository().GetAll().ToList().OrderBy(x => x.ProductName);
            var result = data.Select(x => new ProductViewModel()
            {
                ID = x.ProductID,
                Name = x.ProductName,
                Stock = x.UnitsInStock,
                Price = x.UnitPrice
            });
            return result.ToList();
        }

        public virtual Products Find(int id)
        {
            return ProductRepository().GetByID(id);
        }

        public virtual void Insert(ProductViewModel model)
        {
            ProductRepository().Insert(ToEntity(model));
            UnitOfWork.Commit();
        }
        public virtual void Update(ProductViewModel model)
        {
            ProductRepository().Update(ToEntity(model));
            UnitOfWork.Commit();
        }

        public virtual void Delete(int id)
        {
            ProductRepository().Delete(Find(id));
            UnitOfWork.Commit();
        }
    }
}
