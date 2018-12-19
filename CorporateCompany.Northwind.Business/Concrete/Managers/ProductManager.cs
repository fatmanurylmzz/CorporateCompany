
using AutoMapper;
using CorporateCompany.Core.Aspects.Postsharp.AuthorizationAspects;
using CorporateCompany.Core.Aspects.Postsharp.CacheAspects;
using CorporateCompany.Core.Aspects.Postsharp.LogAspects;
using CorporateCompany.Core.Aspects.Postsharp.PerformanceAspects;
using CorporateCompany.Core.Aspects.Postsharp.TransactionAspects;
using CorporateCompany.Core.Aspects.Postsharp.ValidationAspects;
using CorporateCompany.Core.CrossCuttingConcerns.Caching.Microsoft;
using CorporateCompany.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using CorporateCompany.Northwind.Business.Abstract;
using CorporateCompany.Northwind.Business.ValidationRules.FluentValidation;
using CorporateCompany.Northwind.DataAccess.Abstract;
using CorporateCompany.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateCompany.Northwind.Business.Concrete.Managers
{
    public class ProductManager:IProductService
    {
        private IProductDal _productDal;
        private readonly IMapper _mapper;

        public ProductManager(IProductDal productDal, IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [PerformanceCounterAspect(2)]
       // [SecuredOperation(Roles = "Admin,Editor,Student")]
        public List<Product> GetAll()
        {
            var products = _mapper.Map<List<Product>>(_productDal.GetList());
            return products;

        }

        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductId == id);
        }

        [FluentValidationAspect(typeof(ProductValidatior))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [LogAspect(typeof(FileLogger))]
        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }

        [FluentValidationAspect(typeof(ProductValidatior))]
        public Product Update(Product product)
        {
            return _productDal.Update(product);
        }

        [TransactionScopeAspect]
        [FluentValidationAspect(typeof(ProductValidatior))]
        public void TransactionalOperation(Product product1, Product product2)
        {
            _productDal.Add(product1);
            // Business Codes
            _productDal.Update(product2);
        }
    }
}
