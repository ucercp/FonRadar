using FonRadar.DTOs.InvoceDto;
using FonRadar.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FonRadar.WebApi.Controllers
{
    [AllowAnonymous]
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService; 
        public InvoicesController(IInvoiceService InvoiceService)
        {
            _invoiceService = InvoiceService;
        }

        [HttpGet]
        public IActionResult InvoiceList()
        {
           
            var values = _invoiceService.GetInvoices();
            return Ok(values); 
        }

        [HttpGet("{id}")]
      
        public  IActionResult GetInvoiceById(int id)
        {
            var values =  _invoiceService.GetInvoiceById(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateInvoice(CreateInvoiceDto createInvoiceDto)
        {
            
            _invoiceService.AddInvoice(createInvoiceDto);
            return Ok("Müşteri başarıyla eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteInvoice(int id)
        {
            
            _invoiceService.DeleteInvoice(id);
            return Ok("Müşteri başarıyla silindi"); 
        }

        [HttpPut]
        public IActionResult UpdateInvoice(UpdateInvoiceDto updateInvoiceDto)
        {
           
            _invoiceService.UpdateInvoice(updateInvoiceDto);
            return Ok("Müşteri başarıyla güncellendi"); 
        }
    }
}
