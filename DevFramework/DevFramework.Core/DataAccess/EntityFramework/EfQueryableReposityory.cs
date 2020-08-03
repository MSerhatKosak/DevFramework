using DevFramework.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess.EntityFramework
{
    public class EfQueryableReposityory<T> : IQueryableReposityory<T> where T : class, IEntity, new()
    {
        private DbContext _context;
        private DbSet<T> entites;//Varlıklar
        public EfQueryableReposityory(DbContext dbContext)
        {
            _context = dbContext; //depenceted injections //context alıyoruz
        }
        public IQueryable<T> Table => this.Entityes;
    
        protected virtual DbSet<T> Entityes
        {

            get
            {
                if (entites==null)
                {
                    return entites = _context.Set<T>();//EGER BOŞ İSE gonderilen türe abone ol gonder
                }
                else
                {
                    return entites;//boş degilse gonder bu bir çeşit patern
                }
            }
            //başka biryerde çagırmasınlar diye protected yaptık

        }
    
    }

}
