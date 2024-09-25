using FonRadar.Core.DataAccess.Repositories;
using FonRadar.DTOs.InvoceDto;
using FonRadar.Entities;
using FonRadar.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonRadar.Service.Concrete
{
    public class SupplierService:ISupplierService
    {
        private readonly IEntityRepository<Invoice> _iEntityRepository;

        public SupplierService(IEntityRepository<Invoice> iEntityRepository)
        {
            _iEntityRepository = iEntityRepository;
        }

        public List<ResultInvoiceDto> GetInvoicesBySupplierTaxId(string taxId)
        {
            var invoices = _iEntityRepository.GetList(i => i.SupplierTaxId == taxId);
            var invoiceDtoList = new List<ResultInvoiceDto>();
            foreach (var invoice in invoices)
            {
                invoiceDtoList.Add(new ResultInvoiceDto
                {
                    InvoiceId = invoice.InvoiceId,
                    InvoiceNumber = invoice.InvoiceNumber,
                    TermDate = invoice.TermDate,
                    BuyerTaxId = invoice.BuyerTaxId,
                    SupplierTaxId = invoice.SupplierTaxId,
                    InvoiceCost = invoice.InvoiceCost,
                    Status = invoice.Status
                });
            }
            return invoiceDtoList;
        }

        public void UpdateInvoiceStatus(int invoiceId, InvoiceStatus status)
        {
            var invoice = _iEntityRepository.Get(i => i.InvoiceId == invoiceId);
            if (invoice != null)
            {
                invoice.Status = status;
                _iEntityRepository.Update(invoice);
            }
        }
    }
}

