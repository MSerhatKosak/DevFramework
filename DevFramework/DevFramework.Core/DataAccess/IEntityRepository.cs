using DevFramework.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess
{
  public  interface IEntityRepository<T> where T:class ,IEntity,new()
    {
        List<T> GetList(Expression<Func<T, bool>> filter=null);
        T GetOne(Expression<Func<T, bool>> filter=null);
        T add(T entity);
        T update(T entity);
        T delete(T entity);
        void deleteForVoid(T delete);

    }
}
