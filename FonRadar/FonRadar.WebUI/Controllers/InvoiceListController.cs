using Microsoft.AspNetCore.Mvc;

namespace FonRadar.WebUI.Controllers
{
    public class InvoiceListController : Controller
    {
        public IActionResult Index(string id)
        {
            ViewBag.i = id;
            return View();
        }
    }
}
