using DevFramework.Core.DataAccess.EntityFramework;

using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using DevFramework.Northwind.DataAcces;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.DataAccess.NHibermate;
using DevFramework.Northwind.Entities.ComplexType;

namespace DevFramework.Northwind.DataAcces.Concrete.Nhibernate
{
    public class NhProductDal : NhRepositoryBase<Product>,IProductDal
    {
        private NhibernateHelper _nhHelper;
        public NhProductDal(NhibernateHelper nhibernateHelper) : base(nhibernateHelper)
        {
            _nhHelper = nhibernateHelper;

            //inject
        }

        public List<ProductDetails> GetProductsDetails()
        {

            using (var session = _nhHelper.OpenSession())
            {
                var result = from p in session.Query<Product>()
                             join c in session.Query<Category>() on p.CategoryId equals c.CategoryID
                             select new ProductDetails
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName
                             };
                return result.ToList();
            }
        }
    }
}
