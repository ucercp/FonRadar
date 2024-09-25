using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonRadar.Core.DataAccess.Entities
{
    // BaseEntity sınıfı, tüm varlık sınıfları için temel bir yapı sağlar ve IEntity arayüzünü uygular.
    // Bu sınıf, diğer varlık sınıflarının ortak özelliklerini veya işlevselliğini barındırmak için kullanılır.
    public class BaseEntity : IEntity
    {
        // Şu anda bu sınıf herhangi bir özellik veya metod içermemektedir.
        // İlerleyen aşamalarda tüm varlık sınıfları için ortak olan özellikler (örneğin, Id, CreatedDate, UpdatedDate) buraya eklenebilir.
    }
}
