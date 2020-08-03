using DevFramework.Core.DataAccess;
using DevFramework.Northwind.Entities.ComplexType;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAcces
{
   public interface IProductDal:IEntityRepository<Product>//Nesne gerekli koşulları saglıyor
    {
        List<ProductDetails> GetProductsDetails();
    }
}
