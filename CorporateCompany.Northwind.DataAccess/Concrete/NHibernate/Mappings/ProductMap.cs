using CorporateCompany.Northwind.Entities.Concrete;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateCompany.Northwind.DataAccess.Concrete.NHibernate.Mappings
{
   public class ProductMap:ClassMap<Product>
    {
        public ProductMap()
        {
            Table(@"Products");
            LazyLoad();
            Id(x => x.ProductId).Column("ProductID");


            Map(x => x.CategoryId).Column("CategoryId");
            Map(x => x.ProductName).Column("ProductName");
            Map(x => x.UnitPrice).Column("UnitPrice");
            Map(x => x.QuantityPerUnit).Column("QuantityPerUnit");
        }
    }
}
