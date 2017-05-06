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
    public class DIContainerRepository
    {
        private static Container container;

        public static void RegisterTypes(Container _container) {

            container = _container;

        }

        internal static Container GetContainer()
        {
            return container;
        }

    }
}
