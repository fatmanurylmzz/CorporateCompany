using CorporateCompany.Core.DataAccess.NHibernate;
using CorporateCompany.Northwind.DataAccess.Abstract;
using CorporateCompany.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateCompany.Northwind.DataAccess.Concrete.NHibernate
{
    public class NhCategoryDal : NHEntityRepositoryBase<Category>, ICategoryDal
    {
        public NhCategoryDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
        }
    }
}
