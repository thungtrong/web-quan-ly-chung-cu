using System;
using System.Collections.Generic;
using ManagerApartmentProject.Models;
using ManagerApartmentProject.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ManagerApartmentProject.Controllers
{
    [Authorize]
    [Authorize(Policy = "AdminOrGreater")]
    public class InvoiceBuildingController : Controller
    {
        private readonly ILogger<InvoiceBuildingController> _logger;
        private readonly IInvoiceBuildingRes _invoiceBuildingRes;

        public InvoiceBuildingController(ILogger<InvoiceBuildingController> logger, IInvoiceBuildingRes invoiceBuildingRes)
        {
            _logger = logger;
            _invoiceBuildingRes = invoiceBuildingRes;
        }

        public IActionResult Index()
        {
            List<InvoiceBuilding> lst = _invoiceBuildingRes.GetAll();
            return View(lst);
        }

        public IActionResult Create()
        {
            return View(new InvoiceBuilding());
        }

        [HttpPost]
        [ActionNameAttribute("Create")]
        public IActionResult CreateConfirm(InvoiceBuilding maintenance)
        {
            if (maintenance == null)
            {
                return View(maintenance);
            }
            var creatorId = int.Parse(User.FindFirst("Id").Value);
            
            bool result = _invoiceBuildingRes.Create(maintenance, creatorId);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View(maintenance);
        }

        public IActionResult Detail(int id)
        {
            InvoiceBuilding maintenance = _invoiceBuildingRes.GetById(id);
            if (maintenance == null)
            {
                maintenance = new InvoiceBuilding();
            }
            return View(maintenance);
        }

        public IActionResult Update(int id)
        {
            InvoiceBuilding maintenance = _invoiceBuildingRes.GetById(id);
            if (maintenance == null)
            {
                maintenance = new InvoiceBuilding();
            }
            return View(maintenance);
        }

        [HttpPost, ActionName("Update")]
        public IActionResult UpdateConfirm(int id, InvoiceBuilding maintenance)
        {
            if (maintenance == null)
            {
                return View("Update", maintenance);
            }

            bool result = _invoiceBuildingRes.EditById(id, maintenance);
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View("Update", maintenance);
        }

        [Authorize(Policy = "SuperAdmin")]
        public IActionResult Delete(int id)
        {
            InvoiceBuilding maintenance = _invoiceBuildingRes.GetById(id);
            return View(maintenance);
        }
        
        [Authorize(Policy = "SuperAdmin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id, InvoiceBuilding maintenance)
        {
            if (maintenance == null)
            {
                ViewBag.message = "C?? l???i x???y ra";
                return View("Delete", maintenance);
            }
            bool result = _invoiceBuildingRes.DeleteById(id);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}