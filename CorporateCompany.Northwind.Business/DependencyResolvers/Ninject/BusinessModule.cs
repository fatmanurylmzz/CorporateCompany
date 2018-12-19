using CorporateCompany.Core.DataAccess;
using CorporateCompany.Core.DataAccess.EntityFramework;
using CorporateCompany.Core.DataAccess.NHibernate;
using CorporateCompany.Northwind.Business.Abstract;
using CorporateCompany.Northwind.Business.Concrete.Managers;
using CorporateCompany.Northwind.DataAccess.Abstract;
using CorporateCompany.Northwind.DataAccess.Concrete.EntityFramework;
using CorporateCompany.Northwind.DataAccess.Concrete.NHibernate.Helpers;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateCompany.Northwind.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope(); ;

            Bind<IUserService>().To<UserManager>();
            Bind<IUserDal>().To<EfUserDal>();


            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>));
            Bind<DbContext>().To<NorthwindContext>();
            Bind<NHibernateHelper>().To<SqlServerHelper>();
        }
    }
}
