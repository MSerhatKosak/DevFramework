using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess.NHibermate
{
    public abstract class NhibernateHelper : IDisposable
    {
        private static ISessionFactory _sessionFactory;


        public virtual ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    return _sessionFactory = InitializeFactory();//Gönderdigimiz session factorysini gönderiyoruz
                    //varsa yani sql oracle ne kullanıcaksak onu gönderiyıruz 
                }
                else
                {
                    return _sessionFactory;
                }
            }
        }

        protected abstract ISessionFactory InitializeFactory();//Gönderdigi şeyi aslında kendi belirliyecek 
        //yani ezicek
        public virtual ISession OpenSession()
        {
            return SessionFactory.OpenSession();//Burda gönderilen tür ne ise onu açıyoruz
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);//garagecollectons sessionu açtıgımız zaman kapatma işlemi işlemleri sonlandırma işlerini yapıyoruz
        }
    }
}
