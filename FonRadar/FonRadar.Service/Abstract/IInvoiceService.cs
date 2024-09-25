using FonRadar.DTOs.InvoceDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonRadar.Service.Abstract
{
    public interface IInvoiceService
    {
        List<ResultInvoiceDto> GetInvoices(); 
        GetByIdInvoiceDto GetInvoiceById(int id); 
        void AddInvoice(CreateInvoiceDto createInvoiceDto); 
        void UpdateInvoice(UpdateInvoiceDto updateInvoiceDto); 
        void DeleteInvoice(int id); 
        List<ResultInvoiceDto> GetInvoicesBySupplier(string supplierTaxId);
        void UseInvoice(int invoiceId);    
    }
}
