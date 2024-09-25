using FonRadar.DTOs.InvoceDto;
using FonRadar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonRadar.Service.Abstract
{
    public interface ISupplierService
    { 
        // Tedarikçinin ilişkili olduğu faturaları getir
        List<ResultInvoiceDto> GetInvoicesBySupplierTaxId(string taxId);

        // Faturanın durumunu güncelle 
        void UpdateInvoiceStatus(int invoiceId, InvoiceStatus status);
    }
}
