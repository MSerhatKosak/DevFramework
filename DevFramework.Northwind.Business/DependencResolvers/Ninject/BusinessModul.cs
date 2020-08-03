using DevFramework.Core.DataAccess.NHibermate;
using DevFramework.Northwind.Business.Abstrack;
using DevFramework.Northwind.Business.Concrete.Managers;
using DevFramework.Northwind.DataAcces;
using DevFramework.Northwind.DataAcces.Concrete.EntityFramework;
using DevFramework.Northwind.DataAcces.Concrete.Nhibernate.Helper;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Business.DependencResolvers.Ninject
{
    public class BusinessModul : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManagers>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>();
            Bind<DbContext>().To<NortwindContext>();
            Bind<NhibernateHelper>().To<SqlServerHelper>();
        }
    }
}
