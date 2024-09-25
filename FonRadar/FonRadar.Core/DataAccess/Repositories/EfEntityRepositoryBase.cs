using FonRadar.Core.DataAccess.Entities;
using FonRadar.Core.DataAccess.Repositories; 
using Microsoft.EntityFrameworkCore; 
using System; 
using System.Collections.Generic;
using System.Linq; 
using System.Linq.Expressions; 
using System.Text; 
using System.Threading.Tasks; 

namespace FonRadar.Core.DataAccess.EntityFramework
{
    // Bu sınıf, Entity Framework Core'u kullanarak veritabanı işlemlerini gerçekleştiren temel bir repository sınıfıdır.
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new() // TEntity, IEntity arayüzünü uygulayan ve bir sınıf olmalıdır.
        where TContext : DbContext, new() // TContext, DbContext sınıfından türemiş bir sınıf olmalıdır.
    {
        // Bu metod, isteğe bağlı bir filtre kullanarak TEntity türündeki verilerin listesini döndürür.
        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext()) // Yeni bir veritabanı bağlamı örneği oluşturulur.
            {
                // Eğer filtre sağlanmamışsa, tüm verileri döndürür. Filtre sağlanmışsa, filtreye uyan verileri döndürür.
                return filter == null
                    ? context.Set<TEntity>().ToList() // TEntity türündeki tüm verileri getirir.
                    : context.Set<TEntity>().Where(filter).ToList(); // Filtreye uyan verileri getirir.
            }
        }

        // Bu metod, belirli bir filtreye uyan tek bir TEntity nesnesini döndürür.
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext()) // Yeni bir veritabanı bağlamı örneği oluşturulur.
            {
                // Filtreye uyan ilk TEntity nesnesini döndürür.
                return context.Set<TEntity>().FirstOrDefault(filter);
            }
        }

        // Bu metod, TEntity türünde yeni bir varlık ekler ve eklenen varlığı döndürür.
        public TEntity Add(TEntity entity)
        {
            using (var context = new TContext()) // Yeni bir veritabanı bağlamı örneği oluşturulur.
            {
                var addedEntity = context.Entry(entity); // Eklenecek varlığın bağlam içerisindeki durumu alınır.
                addedEntity.State = EntityState.Added; // Varlığın durumu 'Eklendi' olarak işaretlenir.
                context.SaveChanges(); // Veritabanına değişiklikler kaydedilir.
                return entity; // Eklenen varlık döndürülür.
            }
        }

        // Bu metod, TEntity türünde var olan bir varlığı günceller ve güncellenmiş varlığı döndürür.
        public TEntity Update(TEntity entity)
        {
            using (var context = new TContext()) // Yeni bir veritabanı bağlamı örneği oluşturulur.
            {
                var updatedEntity = context.Entry(entity); // Güncellenecek varlığın bağlam içerisindeki durumu alınır.
                updatedEntity.State = EntityState.Modified; // Varlığın durumu 'Güncellendi' olarak işaretlenir.
                context.SaveChanges(); // Veritabanına değişiklikler kaydedilir.
                return entity; // Güncellenmiş varlık döndürülür.
            }
        }

        // Bu metod, TEntity türünde var olan bir varlığı siler ve silme işleminin başarılı olup olmadığını döndürür.
        public bool Delete(TEntity entity)
        {
            using (var context = new TContext()) // Yeni bir veritabanı bağlamı örneği oluşturulur.
            {
                var deletedEntity = context.Entry(entity); // Silinecek varlığın bağlam içerisindeki durumu alınır.
                deletedEntity.State = EntityState.Deleted; // Varlığın durumu 'Silindi' olarak işaretlenir.
                return context.SaveChanges() > 0 ? true : false; // Değişiklikler kaydedilir ve silme işleminin başarılı olup olmadığı döndürülür.
            }
        }
    }
}
