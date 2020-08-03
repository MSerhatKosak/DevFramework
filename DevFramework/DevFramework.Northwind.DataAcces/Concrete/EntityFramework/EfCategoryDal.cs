using DevFramework.Core.DataAccess.EntityFramework;
using DevFramework.Northwind.DataAcces.Abstrack;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAcces.Concrete.EntityFramework
{
    public class EfCategoryDal:EfEntityRepositoryBase<Category,NortwindContext>,ICategoryDal
    {
    }
}
