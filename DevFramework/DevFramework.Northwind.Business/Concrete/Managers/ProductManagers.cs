using DevFramework.Core.Aspects.PostSharp;
using DevFramework.Northwind.Business.Abstrack;
using DevFramework.Northwind.Business.ValidationRules.FluentValidator;
using DevFramework.Northwind.DataAcces;
using DevFramework.Northwind.Entities.Concrete;
using System.Collections.Generic;

namespace DevFramework.Northwind.Business.Concrete.Managers
{
    public class ProductManagers : IProductService
    {
        private IProductDal _productDal;
        public ProductManagers( IProductDal productDal)
        {
            _productDal = productDal;
        }

        public Product Add(Product product)
        {
         //   ValidatorTool.FluentValidate(new ProductValidator(), product); //bu bir çeşidşi
            return _productDal.add(product);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public Product GetById(int id)
        {
            return _productDal.GetOne(p => p.ProductId == id);
        }

        [FluentDationsAspect(typeof(ProductValidator))]
        public Product Update(Product product)
        {
            return _productDal.update(product);
        }
    }
}
