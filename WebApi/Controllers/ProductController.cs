using BLL;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class ProductController : ApiController
    {

        private IProductLogic productLogic;
        public ProductController(IProductLogic _productLogic)
        {
            productLogic = _productLogic;
        }

        //Get All Products
        [HttpGet]
        public IEnumerable<ProductViewModel> GetAllProducts()
        {
            return productLogic.List();
        }


        //Get the single product data
        [HttpGet]
        public ProductViewModel GetProduct(int id)
        {
            var data = productLogic.Find(id);
            if (data != null)
            {
                return productLogic.ToModel(data);
            }
            else
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
        }

        //Add new product

        [HttpPost]
        public HttpResponseMessage AddProduct(ProductViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    productLogic.Insert(model);
                    return Request.CreateResponse(HttpStatusCode.Created, "Kayit Basarili");
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Hatali bilgi girdiniz !");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "İşlem sırasında hata olustu !", ex);
            }
        }

        //Update the product

        [HttpPut]
        public HttpResponseMessage UpdateProduct(ProductViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    productLogic.Update(model);
                    return Request.CreateResponse(HttpStatusCode.Created, "Kayit Basarili");
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Hatali bilgi girdiniz !");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "İşlem sırasında hata olustu !", ex);
            }
        }

        //Delete the product

        [HttpDelete]
        public HttpResponseMessage DeleteProduct(int id)
        {

            if (productLogic.Find(id) != null)
            {
                productLogic.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, productLogic.Find(id));
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Kayit mevcut degil !");
            }
        }
    }
}