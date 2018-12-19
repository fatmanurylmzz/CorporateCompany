using CorporateCompany.Core.Utilities.Common;
using CorporateCompany.Northwind.Business.Abstract;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateCompany.Northwind.Business.DependencyResolvers.Ninject
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().ToConstant(WcfProxy<IProductService>.CreateChannel());
        }
    }
}
