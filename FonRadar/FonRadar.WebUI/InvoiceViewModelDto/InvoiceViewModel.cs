﻿using FonRadar.Entities;

namespace FonRadar.WebUI.InvoiceViewModelDto
{
    public class InvoiceViewModel
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
