using DevFramework.Northwind.DataAcces.Concrete.EntityFramework.Mapping;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAcces.Concrete.EntityFramework
{
   public class NortwindContext:DbContext
    {
        public NortwindContext()
        {
            Database.SetInitializer<NortwindContext>(null);//burda diyoruz ki sen gidip birşey oluşturma 
            //
        }
        public DbSet<Product> Products { get; set; }//s ile biten products tablo adı
        public DbSet<Category> Categories { get; set; }//s ile biten products tablo adı

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());//Yaptıgımız mappingi ayaga kaldırıyoruz burda
        }
    }
}
