using System;
using DevFramework.Northwind.DataAcces.Concrete.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevFramework.Northwind.DataAcces.Tests.EntityFrameworkTests
{
    [TestClass]
    public class EntityFrameworktTest
    {
        [TestMethod]
        public void get_all_return_all_product()
        {
            EfProductDal ef = new EfProductDal();
            //ef imlemente edilmiyordu çünkü nesneyi direk alıyor test yazarken referans olarak eklememiz lazım 
            var result = ef.GetList();

            Assert.AreEqual(79, result.Count);
        }
        [TestMethod]
        public void get_parameter_return_on_filter()
        {
            EfProductDal ef = new EfProductDal();
            //ef imlemente edilmiyordu çünkü nesneyi direk alıyor test yazarken referans olarak eklememiz lazım 
            var result = ef.GetList(x => x.ProductName.Contains("ab"));

            Assert.AreEqual(4, result.Count);
        }

    }
}
