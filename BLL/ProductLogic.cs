using BLL.Models;
using DryIoc;
using ORM;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProductLogic
    {

        private static IRepository<Products> PrdctRepos()
        {
            var prdct = UoW().Repository<Products>();
            return prdct;
        }

        private static IUnitOfWork UoW()
        {
            var container = new Container();
            var uow = container.Resolve<IUnitOfWork>();
            return uow;
        }

        public static ProductViewModel ToModel(Products data)
        {
            ProductViewModel product = new ProductViewModel();
            product.Name = data.ProductName;
            product.Stock = data.UnitsInStock;
            product.Price = data.UnitPrice;
            return product;
        }

        public static Products ToEntity(ProductViewModel model)
        {
            Products prdct = new Products();
            prdct.ProductName = model.Name;
            prdct.UnitsInStock = model.Stock;
            prdct.UnitPrice = model.Price;
            return prdct;
        }

        public static IEnumerable<ProductViewModel> List()
        {
            var data = PrdctRepos().GetAll().ToList().OrderBy(x => x.ProductName);
            var result = data.Select(x => new ProductViewModel()
            {
                Name = x.ProductName,
                Stock = x.UnitsInStock,
                Price = x.UnitPrice
            });
            return result.ToList();
        }

        public static Products Find(int id)
        {
            return PrdctRepos().GetByID(id);
        }

        public static void Insert(ProductViewModel model)
        {
            PrdctRepos().Insert(ToEntity(model));
            UoW().Commit();
        }
        public static void Update(ProductViewModel model)
        {
            PrdctRepos().Update(ToEntity(model));
            UoW().Commit();
        }

        public static void Delete(int id)
        {
            PrdctRepos().Delete(Find(id));
            UoW().Commit();
        }
    }
}
