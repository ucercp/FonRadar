using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonRadar.Entities
{
    public class InvoiceEvent
    {
        public string InvoiceNumber { get; set; }
        public string SupplierTaxId { get; set; }
        public DateTime TermDate { get; set; }

        public InvoiceEvent(string invoiceNumber, string supplierTaxId, DateTime termDate)
        {
            InvoiceNumber = invoiceNumber;
            SupplierTaxId = supplierTaxId;
            TermDate = termDate;
        }
    }
}
