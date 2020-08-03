using DevFramework.Core.DataAccess.NHibermate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Dialect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAcces.Concrete.Nhibernate.Helper
{
    public class SqlServerHelper : NhibernateHelper
    {
        protected override global::NHibernate.ISessionFactory InitializeFactory()
        {
            //altta sessionfacktory yani devframework coreda yazmış oldugumuz kodu enjecte etik
            //burda veri tabanınıa baglanıyor mappinleri alıyor ve gönderiyoruz
            return Fluently.Configure().Database(MsSqlConfiguration.MsSql2012
                .ConnectionString(c => c.FromConnectionStringWithKey("NortwindContext")))
                 .Mappings(t => t.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly())).BuildSessionFactory();
               
               
        }
    }
}
