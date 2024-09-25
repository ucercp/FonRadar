using System;
using FonRadar.Core.DataAccess.Entities;

namespace FonRadar.Entities
{
    public class Invoice : IEntity
    {
        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime TermDate { get; set; }
        public string BuyerTaxId { get; set; }
        public string SupplierTaxId { get; set; }
        public string InvoiceCost { get; set; }
        public InvoiceStatus Status { get; set; }

        public Supplier Supplier { get; set; }  
    }
}
