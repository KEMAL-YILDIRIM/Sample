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
    public class Dependencies
    {
        public static IContainer container;
        public static void Register(IContainer _container)
        {
            container = _container;
        }

    }
}
