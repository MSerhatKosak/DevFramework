using System;
using DevFramework.Northwind.DataAcces.Concrete.Nhibernate;
using DevFramework.Northwind.DataAcces.Concrete.Nhibernate.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevFramework.Northwind.DataAcces.Tests.NhibernateTests
{
    [TestClass]
    public class NhhibernateTest
    {
        [TestMethod]
        public void Nhibernate_all_return_data()
        {
            NhProductDal nh = new NhProductDal(new SqlServerHelper());
            //ef imlemente edilmiyordu çünkü nesneyi direk alıyor test yazarken referans olarak eklememiz lazım 
           
            var result = nh.GetList();
          

            Assert.AreEqual(79, result.Count);
        }
    }
}
