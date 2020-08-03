using DevFramework.Core.Entity;
using NHibernate.Id.Insert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess.NHibermate
{
    public class NhibernateRepository<T> : IQueryableReposityory<T> where T : class, IEntity, new()
    {
        private NhibernateHelper _nhibernateHelper;
        private IQueryable<T> _entities;
        public NhibernateRepository(NhibernateHelper nhibernateHelper)
        {
            _nhibernateHelper = nhibernateHelper;
        }
        public IQueryable<T> Table => this.Entities;
        public IQueryable<T> Entities
        {
            get
            {

                if (_entities == null)
                {
                    return _entities = _nhibernateHelper.OpenSession().Query<T>();
                }
                else
                {
                    return _entities;
                }
            }
        }

    }
}
