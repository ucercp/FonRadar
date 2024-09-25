using FonRadar.Core.DataAccess.EntityFramework;
using FonRadar.DataAccess.Abstract;
using FonRadar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonRadar.DataAccess.Concrete
{
    public class InvoiceDal : EfEntityRepositoryBase<Invoice, FonRadarContext>, IInvoiceDal
    {
    }
}
