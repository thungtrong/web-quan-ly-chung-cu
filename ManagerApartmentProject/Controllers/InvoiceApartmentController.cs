using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ManagerApartmentProject.Controllers
{

    public class InvoiceApartment : Controller
    {
        private readonly ILogger<InvoiceApartment> _logger;
        public InvoiceApartment(ILogger<InvoiceApartment> logger){
            _logger = logger;
        }

        public IActionResult Index(){
            return View();
        }
    }
}