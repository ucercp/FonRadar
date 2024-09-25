
using AutoMapper;
using FonRadar.Core.DataAccess.Repositories;
using FonRadar.DataAccess.Abstract;
using FonRadar.DTOs.InvoceDto;
using FonRadar.Entities;
using FonRadar.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FonRadar.Service.Concrete
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IEntityRepository<Invoice> _entityRepository;
        private readonly IPublisEvent _publisEvent;
        private readonly IInvoiceDal _invoiceDal;
        private readonly IMapper _mapper;

        public InvoiceService(IEntityRepository<Invoice> entityRepository, IPublisEvent publisEvent, IInvoiceDal invoiceDal, IMapper mapper)
        {
            _entityRepository = entityRepository;
            _publisEvent = publisEvent;
            _invoiceDal = invoiceDal;
            _mapper = mapper;
        }

        public void AddInvoice(CreateInvoiceDto createInvoiceDto)
        {
            var values = _mapper.Map<Invoice>(createInvoiceDto);
            _invoiceDal.Add(values);
        }

        public void DeleteInvoice(int id)
        {
            var values = _invoiceDal.Get(c => c.InvoiceId == id);
            if (values != null)
            {
                _invoiceDal.Delete(values);
            }
            else
            {
                throw new Exception("Fatura Bulunamadı");
            }
        }

        public List<ResultInvoiceDto> GetInvoices()
        {
            var values = _invoiceDal.GetList();
            var valuesDto = _mapper.Map<List<ResultInvoiceDto>>(values);
            return valuesDto;
        }

        public GetByIdInvoiceDto GetInvoiceById(int id)
        {
            var invoice = _invoiceDal.Get(x => x.InvoiceId == id);

            if (invoice == null)
            {
                throw new Exception("Fatura bulunamadı.");
            }

            return _mapper.Map<GetByIdInvoiceDto>(invoice);
        }

        public void UpdateInvoice(UpdateInvoiceDto updateInvoiceDto)
        {
            var values = _mapper.Map<Invoice>(updateInvoiceDto);
            _invoiceDal.Update(values);
        }

        public List<ResultInvoiceDto> GetInvoicesBySupplier(string supplierTaxId)
        {
            var invoices = _invoiceDal.GetList(x => x.SupplierTaxId == supplierTaxId); 
            var valuesDto = _mapper.Map<List<ResultInvoiceDto>>(invoices);
            return valuesDto;
        }

        public void UseInvoice(int invoiceId)
        {
            var invoice = _invoiceDal.Get(x => x.InvoiceId == invoiceId);
            if (invoice == null)
            {
                throw new Exception("Fatura bulunamadı.");
            }
         
            invoice.Status = InvoiceStatus.Used;
            _invoiceDal.Update(invoice);
            _publisEvent.Publish(invoice); 
        }
    }
}
