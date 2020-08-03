using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.DataAcces.Concrete.EntityFramework.Mapping
{
   public class ProductMap:EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            //Configrasyonu yapıcı metod ile baglıyoruz bu ilerde nesne isimlerini degiştirirsek
            //veya türkce bir tablo kullanıyorsak 
            //Productı tablodaki columa baglamamıza yardım edicek
            ToTable(@"Products", @"dbo");
            HasKey(x => x.ProductId);

            Property(x => x.ProductId).HasColumnName("ProductID");
            Property(x => x.CategoryId).HasColumnName("CategoryID");
            Property(x => x.ProductName).HasColumnName("ProductName");
            Property(x => x.QuantityPerUnit).HasColumnName("QuantityPerUnit");
            Property(x => x.UnitPrice).HasColumnName("UnitPrice");//GEREKLİ KISINLARI İLİŞKİLENDİRDİK
            Property(x => x.UnitsInStock).HasColumnName("UnitsInStock");

        }
    }
}
