using BLL;
using DryIoc;
using ORM;
using Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

public class DIRegistrations
{

    public static Container container;

    public static void RegisterDependencies()
    {

        container = container ?? new Container(rules => rules.WithoutThrowOnRegisteringDisposableTransient());

        container.UseInstance<DbContext>(new EF_DbContext());
        container.Register(typeof(IRepository<>), typeof(GenericRepository<>));
        container.Register<IUnitOfWork, UnitOfWork>(Reuse.Singleton);

        DIContainerRepository.RegisterTypes(container);
        DIContainerBLL.RegisterTypes(container);
    }

}