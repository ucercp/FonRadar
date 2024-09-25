using FonRadar.Entities;
using FonRadar.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonRadar.Service.Concrete
{
    public class SupplierDeclarationHandler : IHandlerEvent<InvoiceEvent>
    {
        public void Handle(InvoiceEvent eventMessage)
        {
            Console.WriteLine($"Tedarikçiye bildirim gönderiliyor: {eventMessage.SupplierTaxId} için yeni fatura {eventMessage.InvoiceNumber}");
        }
    }
}
