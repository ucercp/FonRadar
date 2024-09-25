using FonRadar.Entities;
using FonRadar.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FonRadar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        // Tedarikçinin vergi numarasına göre faturaları getir
        [HttpGet("invoices/{taxId}")]
        public IActionResult GetInvoicesBySupplierTaxId(string taxId)
        {
            var invoices = _supplierService.GetInvoicesBySupplierTaxId(taxId);
            return Ok(invoices);
        }

      
        [HttpPut("invoice/{id}/status")]
        public IActionResult UpdateInvoiceStatus(int id, [FromBody] InvoiceStatus status)
        {
            _supplierService.UpdateInvoiceStatus(id, status);
            return Ok("Fatura durumu güncellendi");
        }
    }
}
