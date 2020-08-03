using DevFramework.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;
using System.IO;

namespace DevFramework.Core.DataAccess.NHibermate
{
    public class NhRepositoryBase<Tentiy> : IEntityRepository<Tentiy>
        where Tentiy : class, IEntity, new()

    {
        private NhibernateHelper _nhhibernateHelper;
        public NhRepositoryBase(NhibernateHelper nhibernate)
        {
            _nhhibernateHelper = nhibernate;
        }
        public Tentiy add(Tentiy entity)
        {
            using (var session = _nhhibernateHelper.OpenSession())
            {
                //constructer metodda zaten veritabanı türünü alıyoruz
                session.Save(entity);//kendi mapping yapıp bulucak
                return entity;
            }
        }

        public Tentiy delete(Tentiy entity)
        {
            using (var session = _nhhibernateHelper.OpenSession())
            {
                
                session.Delete(entity);
                return entity;
            }
        }

        public void deleteForVoid(Tentiy delete)
        {
            using (var session = _nhhibernateHelper.OpenSession())
            {
                //constructer metodda zaten veritabanı türünü alıyoruz
                session.Delete(delete);//kendi mapping yapıp bulucak

            }
        }

        public List<Tentiy> GetList(Expression<Func<Tentiy, bool>> filter=null)
        {
            using (var session = _nhhibernateHelper.OpenSession())
            {
               
                return filter == null
                    ? session.Query<Tentiy>().ToList()
                    : session.Query<Tentiy>().Where(filter).ToList();// a filter??
            }
        }
    

    public Tentiy GetOne(Expression<Func<Tentiy, bool>> filter = null)
    {
        using (var session = _nhhibernateHelper.OpenSession())
        {
            //constructer metodda zaten veritabanı türünü alıyoruz //kendi mapping yapıp bulucak
            return session.Query<Tentiy>().SingleOrDefault(filter);
        }
    }

    public Tentiy update(Tentiy entity)
    {
        using (var session = _nhhibernateHelper.OpenSession())
        {
            //constructer metodda zaten veritabanı türünü alıyoruz
            session.Update(entity);//kendi mapping yapıp bulucak
            return entity;
        }
    }
}
}
