using DevFramework.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<Tentity, TContext> : IEntityRepository<Tentity>
        where Tentity:class ,IEntity,new()
        where TContext:DbContext,new()
        //Burada basemiz burası ve IEntity yani gelen veri türünün 
        //bir hata ile karşılaşmamasaı için böyle bir şey yaptık IEntityRepository metodlarımızın yazıdıgı 
        //bir interface bu clas ise işlemlerin yapdıgımız kısım
        
    {
        public Tentity add(Tentity entity)
        {
            using (var contex = new TContext())
            {
                var AddedEntity = contex.Entry(entity);//Datayı degere alıyoruz
                AddedEntity.State = EntityState.Added;//Gelen datayı eklenicek olarak ayarlıyor
                contex.SaveChanges();//Veriyi context sayesınde kaydediyoruz
                return entity;
            }
        }

        public Tentity delete(Tentity entity)
        {
            using (var contex = new TContext())
            {
                var AddedEntity = contex.Entry(entity);//Datayı degere alıyoruz
                AddedEntity.State = EntityState.Deleted;//Gelen datayı silinecek olarak ayarlıyor
                contex.SaveChanges();//Veriyi context sayesınde kaydediyoruz
                return entity;
            }
        }

        public void deleteForVoid(Tentity delete)
        {
            using (var contex = new TContext())
            {
                var AddedEntity = contex.Entry(delete);//Datayı degere alıyoruz
                AddedEntity.State = EntityState.Added;//Gelen datayı eklenicek olarak ayarlıyor
                contex.SaveChanges();//Veriyi context sayesınde kaydediyoruz
              
            }
        }

        public List<Tentity> GetList(Expression<Func<Tentity, bool>> filter=null)
        {
            using (var contex = new TContext())
            {
                return filter == null
                    ? contex.Set<Tentity>().ToList()
                    : contex.Set<Tentity>().Where(filter).ToList();//Burada if koşulu yazdık
                //contex.set ederken Tentity'e abone oluyoruz 
            }

        }

        public Tentity GetOne(Expression<Func<Tentity, bool>> filter)
        {
            using (var contex = new TContext())
            {
                return contex.Set<Tentity>().SingleOrDefault(filter);
            }
        }
        public Tentity update(Tentity entity)
        {
            using (var contex = new TContext())
            {
                var AddedEntity = contex.Entry(entity);//Datayı degere alıyoruz
                AddedEntity.State = EntityState.Modified;//Gelen datayı Güncellenecek olarak ayarlıyor
                contex.SaveChanges();//Veriyi context sayesınde kaydediyoruz
                return entity;
            }
        }
    }
}
