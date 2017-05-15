using BLL;
using DryIoc;
using DryIoc.WebApi;
using ORM;
using Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "GetAPI",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { controller = "Product", action = "GetAllProducts", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );




            IContainer container = new Container()
                .WithWebApi(config);

            container.UseInstance<DbContext>(new EF_DbContext(),preventDisposal:true);
            container.Register(typeof(IRepository<>), typeof(Repository<>));
            container.Register<IUnitOfWork, UnitOfWork>(Reuse.Singleton);

            container.Register<IProductLogic, ProductLogic>();


            Dependencies.Register(container);
        }
    }
}
