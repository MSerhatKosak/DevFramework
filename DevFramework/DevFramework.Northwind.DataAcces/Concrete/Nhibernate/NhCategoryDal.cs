using DevFramework.Core.DataAccess.NHibermate;
using DevFramework.Northwind.DataAcces.Abstrack;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAcces.Concrete.Nhibernate
{
   public class NhCategoryDal:NhRepositoryBase<Category>,ICategoryDal
    {
        public NhCategoryDal(NhibernateHelper nhibernateHelper) : base(nhibernateHelper)
        {

            //BU KISIMDA ZTEN ENJETE EDİLİYOR   
        }
    }
}
