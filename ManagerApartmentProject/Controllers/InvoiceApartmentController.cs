using System.Collections.Generic;
using System.Text.Json;
using ManagerApartmentProject.Models;
using ManagerApartmentProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ManagerApartmentProject.Controllers
{

    public class InvoiceApartmentController : Controller
    {
        private readonly ILogger<InvoiceApartment> _logger;
        private readonly IInvoiceApartmentRes _invoiceApartmentRes;
        public InvoiceApartmentController(ILogger<InvoiceApartment> logger, IInvoiceApartmentRes invoiceApartmentRes)
        {
            _logger = logger;
            _invoiceApartmentRes = invoiceApartmentRes;
        }

        public IActionResult Index()
        {
            // Check quyen sau do lua chon cach thuc load
            List<InvoiceApartment> lst = _invoiceApartmentRes.GetAll();
            return View(lst);
        }

        public IActionResult Detail(int id)
        {
            InvoiceApartmentViewModel model = _invoiceApartmentRes.GetById(id);
            return View(model);
        }
        
        public IActionResult Update(int id)
        {
            InvoiceApartmentViewModel model = _invoiceApartmentRes.GetById(id);
            return View(model);
        }

        [HttpPost]
        public string Update(int id, InvoiceApartmentViewModel model)
        {
            bool result = _invoiceApartmentRes.UpdateById(id, model);
            
            return JsonSerializer.Serialize(new {
                status = result,
                message = result ? "Success" : "Error"
            });
        } 

        public IActionResult Create()
        {
            return View(new InvoiceApartmentViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int id, InvoiceApartmentViewModel model)
        {
            return RedirectToAction("Index");
        }

        
    }
}