using CorporateCompany.Core.DataAccess.EntityFramework;
using CorporateCompany.Northwind.DataAccess.Abstract;
using CorporateCompany.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateCompany.Northwind.DataAccess.Concrete.EntityFramework
{
   public class EfCategoryDal:EfEntityRepositoryBase<Category,NorthwindContext>,ICategoryDal
    {
    }
}
