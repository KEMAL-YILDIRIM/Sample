using DryIoc;
using ORM;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI
{
    public class DIRegistrations
    {
        public static void RegisterDependencies()
        {
            Container container = new Container(rules =>
            rules.WithoutThrowOnRegisteringDisposableTransient().
            WithTrackingDisposableTransients().
            WithDefaultReuseInsteadOfTransient(Reuse.InWebRequest)
            );
            container.UseInstance(new EF_DbContext());
            container.Register<IUnitOfWork, UnitOfWork>(Reuse.Singleton);
            container.Register(typeof(IRepository<>), typeof(GenericRepository<>));
        }
    }
}