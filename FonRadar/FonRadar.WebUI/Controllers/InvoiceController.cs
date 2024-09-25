
using FonRadar.DTOs.InvoceDto;
using FonRadar.WebUI.InvoiceViewModelDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

[Area("Admin")]
[Route("Admin/Invoice")]
public class InvoiceController : Controller
{

    private readonly HttpClient _httpClient;

    public InvoiceController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        var response = await _httpClient.GetAsync("http://localhost:7080/api/Invoices");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();

            var values = JsonConvert.DeserializeObject<List<InvoiceViewModel>>(jsonData);

            return View(values);
        }
        return View(new List<InvoiceViewModel>());
    }
}

