using DevFramework.Core.DataAccess.EntityFramework;
using DevFramework.Northwind.Entities.ComplexType;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAcces.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NortwindContext>, IProductDal//Contexti oluşturduk repositorybaseden alıyoruz
                                                                                             //Ve bu işlemleri hangi veritabanına kaydedicegimiz söylicez
    {
        public List<ProductDetails> GetProductsDetails()
        {
            //List<ProductDetails> productDetails = new List<ProductDetails>();
            using (NortwindContext context = new NortwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories on p.CategoryId equals c.CategoryID
                             select new ProductDetails
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName
                             };

                //productDetails.Add((ProductDetails)result);
                //return productDetails.ToList();

                return result.ToList();
            }

            
        }

       
    }
}
