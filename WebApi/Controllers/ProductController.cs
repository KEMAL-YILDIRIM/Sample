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

        //Get All Products
        [HttpGet]
        public IEnumerable<ProductViewModel> GetAllProducts()
        {
            return ProductLogic.List();
        }


        //Get the single product data
        [HttpGet]
        public ProductViewModel GetProduct(int id)
        {
            var data = ProductLogic.Find(id);
            if (data != null)
            {
                return ProductLogic.ToModel(data);
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
                    ProductLogic.Insert(model);
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
                    ProductLogic.Update(model);
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

            if (ProductLogic.Find(id) != null)
            {
                ProductLogic.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, ProductLogic.Find(id));
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Kayit mevcut degil !");
            }
        }
    }
}