using CorporateCompany.Northwind.Business.Abstract;
using CorporateCompany.Northwind.Business.DependencyResolvers.Ninject;
using CorporateCompany.Northwind.Business.ServiceContracts.Wcf;
using CorporateCompany.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductDetailService
/// </summary>
public class ProductDetailService : IProductDetailService
{
    private IProductService _productService = InstanceFactory.GetInstance<IProductService>();
    public List<Product> GetAll()
    {
        return _productService.GetAll();
    }
}