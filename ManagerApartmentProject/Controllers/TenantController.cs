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
    public class TenantController : Controller
    {
        private readonly ILogger<TenantController> _logger;
        private readonly ITenantRes _tenantRes;

        public TenantController(ILogger<TenantController> logger, ITenantRes tenantRes){
            _logger = logger;
            _tenantRes = tenantRes;
        }

        public IActionResult Index(){
            List<Tenant> lst = _tenantRes.GetAll();
            return View(lst);
        }

        public IActionResult Create(){
            return View(new Tenant());
        }

        [HttpPost]
        [ActionNameAttribute("Create")]
        public IActionResult CreateConfirm(Tenant tenant){
            if (tenant == null){
                return View(tenant);
            }
            var creatorId = int.Parse(User.FindFirst("Id").Value);
            bool result = _tenantRes.Create(tenant);
            if (result){
                return RedirectToAction("Index");
            }
            return View(tenant);
        }

        public IActionResult Detail(int id){
            Tenant tenant = _tenantRes.GetById(id);
            if (tenant == null){
                tenant = new Tenant();
            }
            return View(tenant);
        }

        public IActionResult Update(int id){
            Tenant tenant = _tenantRes.GetById(id);
            if (tenant == null){
                tenant = new Tenant();
            }
            return View(tenant);
        }

        [HttpPost]
        [ActionNameAttribute("Update")]
        public IActionResult UpdateConfirm(int id, Tenant tenant){
            if (tenant == null){
                return View("Update", tenant);
            }
            
            bool result = _tenantRes.EditById(id, tenant);
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View("Update",tenant);
        }
        public IActionResult Delete(int id){
            Tenant tenant = _tenantRes.GetById(id);
            return View(tenant);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id, Tenant tenant){
            if (tenant == null){
                ViewBag.message = "Có lỗi xảy ra";
                return View("Delete", tenant);
            }
            bool result = _tenantRes.DeleteById(id);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}