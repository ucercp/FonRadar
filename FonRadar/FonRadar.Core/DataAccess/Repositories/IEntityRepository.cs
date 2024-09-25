using FonRadar.Core.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FonRadar.Core.DataAccess.Repositories
{
    // Bu arayüz, T türündeki varlıklar üzerinde gerçekleştirilecek temel veri erişim işlemlerini tanımlar.
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetList(Expression<Func<T, bool>> filter = null);// Bu metod, isteğe bağlı bir filtre kullanarak T türündeki verilerin listesini döndürür.
        T Get(Expression<Func<T, bool>> filter);// Bu metod, belirli bir filtreye uyan tek bir T türündeki varlığı döndürür.
        T Add(T entity);// Bu metod, veritabanına yeni bir T türündeki varlık ekler ve eklenen varlığı döndürür.
        T Update(T entity);// Bu metod, T türündeki var olan bir varlığı günceller ve güncellenmiş varlığı döndürür.
        bool Delete(T entity);// Bu metod, T türündeki var olan bir varlığı siler ve silme işleminin başarılı olup olmadığını döndürür.

    }
}
