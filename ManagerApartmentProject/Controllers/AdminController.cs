using System;
using System.Collections.Generic;
using ManagerApartmentProject.Models;
using ManagerApartmentProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ManagerApartmentProject.Controllers
{

    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IAdminRes _adminRes;

        public AdminController(ILogger<AdminController> logger, IAdminRes adminRes){
            _logger = logger;
            _adminRes = adminRes;
        }

        public IActionResult Index(){
            List<Admin> lst = _adminRes.GetAll();
            return View(lst);
        }

        public IActionResult Create(){
            return View(new Admin());
        }

        [HttpPost]
        [ActionNameAttribute("Create")]
        public IActionResult CreateConfirm(Admin admin){
            if (admin == null){
                return View(admin);
            }
            var creatorId = Convert.ToInt32(Request.Cookies["Id"]);
            bool result = _adminRes.Create(admin, creatorId);
            if (result){
                return RedirectToAction("Index");
            }
            return View(admin);
        }

        public IActionResult Detail(int id){
            Admin admin = _adminRes.GetById(id);
            if (admin == null){
                admin = new Admin();
            }
            return View(admin);
        }

        public IActionResult Update(int id){
            Admin admin = _adminRes.GetById(id);
            if (admin == null){
                admin = new Admin();
            }
            return View(admin);
        }

        [HttpPost]
        [ActionNameAttribute("Update")]
        public IActionResult UpdateConfirm(int id, Admin admin){
            if (admin == null){
                return View("Update", admin);
            }
            
            bool result = _adminRes.EditById(id, admin);
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View("Update",admin);
        }
        public IActionResult Delete(int id){
            Admin admin = _adminRes.GetById(id);
            return View(admin);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id, Admin admin){
            if (admin == null){
                ViewBag.message = "Có lỗi xảy ra";
                return View("Delete", admin);
            }
            bool result = _adminRes.DeleteById(id);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}