using FonRadar.Core.DataAccess.Repositories;
using FonRadar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonRadar.DataAccess.Abstract
{
    public interface IInvoiceDal : IEntityRepository<Invoice>
    {
    }
}
