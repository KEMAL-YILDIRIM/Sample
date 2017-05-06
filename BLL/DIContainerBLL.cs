using DryIoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DIContainerBLL
    {

        private static Container container;

        public static void RegisterTypes(Container _container)
        {

            container = _container;

        }

        internal static Container GetContainer()
        {
            return container;
        }

    }
}
