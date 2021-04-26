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
    public class MaintenanceController : Controller
    {
        private readonly ILogger<MaintenanceController> _logger;
        private readonly IMaintenanceRes _maintenanceRes;

        public MaintenanceController(ILogger<MaintenanceController> logger, IMaintenanceRes maintenanceRes){
            _logger = logger;
            _maintenanceRes = maintenanceRes;
        }

        public IActionResult Index(){
            List<Maintenance> lst = _maintenanceRes.GetAll();
            return View(lst);
        }

        public IActionResult Create(){
            return View(new Maintenance());
        }

        [HttpPost]
        [ActionNameAttribute("Create")]
        public IActionResult CreateConfirm(Maintenance maintenance){
            if (maintenance == null){
                return View(maintenance);
            }
            var creatorId = Convert.ToInt32(Request.Cookies["Id"]);
            bool result = _maintenanceRes.Create(maintenance, creatorId);
            if (result){
                return RedirectToAction("Index");
            }
            return View(maintenance);
        }

        public IActionResult Detail(int id){
            Maintenance maintenance = _maintenanceRes.GetById(id);
            if (maintenance == null){
                maintenance = new Maintenance();
            }
            return View(maintenance);
        }

        public IActionResult Update(int id){
            Maintenance maintenance = _maintenanceRes.GetById(id);
            if (maintenance == null){
                maintenance = new Maintenance();
            }
            return View(maintenance);
        }

        [HttpPost]
        [ActionNameAttribute("Update")]
        public IActionResult UpdateConfirm(int id, Maintenance maintenance){
            if (maintenance == null){
                return View("Update", maintenance);
            }
            
            bool result = _maintenanceRes.EditById(id, maintenance);
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View("Update",maintenance);
        }
        public IActionResult Delete(int id){
            Maintenance maintenance = _maintenanceRes.GetById(id);
            return View(maintenance);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id, Maintenance maintenance){
            if (maintenance == null){
                ViewBag.message = "Có lỗi xảy ra";
                return View("Delete", maintenance);
            }
            bool result = _maintenanceRes.DeleteById(id);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}