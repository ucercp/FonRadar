using System;
using FonRadar.Entities;

namespace FonRadar.DTOs.InvoceDto
{
    public class CreateInvoiceDto
    {
        public string InvoiceNumber { get; set; }
        public DateTime TermDate { get; set; }
        public string BuyerTaxId { get; set; }
        public string SupplierTaxId { get; set; }
        public string InvoiceCost { get; set; }
        public InvoiceStatus Status { get; set; } 

        public Supplier Supplier { get; set; }
    }
 
}
