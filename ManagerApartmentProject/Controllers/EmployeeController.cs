using System;
using System.Collections.Generic;
using System.Text.Json;
using ManagerApartmentProject.Const;
using ManagerApartmentProject.Models;
using ManagerApartmentProject.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ManagerApartmentProject.Controllers
{
    [Authorize]
    [Authorize(Policy = "AdminOrGreater")]
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeRes _employeeRes;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeRes employeeRes){
            _logger = logger;
            _employeeRes = employeeRes;
        }

        public IActionResult Index(){
            List<Employee> lst = _employeeRes.GetAll();
            return View(lst);
        }

        public IActionResult Create(){
            return View(new Employee());
        }

        [HttpPost]
        [ActionNameAttribute("Create")]
        public IActionResult CreateConfirm(Employee employee){
            if (employee == null){
                return View(employee);
            }
            bool result = _employeeRes.Create(employee);
            if (result){
                Account account = new Account{
                    username = ConstValue.RemoveUnicode(employee.name),
                    authority = 2,
                    accountOf = employee.ID
                };
                TempData["account"] = JsonSerializer.Serialize(account);
                return RedirectToAction("Register", "Auth");
            }
            return View(employee);
        }

        public IActionResult Detail(int id){
            Employee employee = _employeeRes.GetById(id);
            if (employee == null){
                employee = new Employee();
            }
            return View(employee);
        }

        public IActionResult Update(int id){
            Employee employee = _employeeRes.GetById(id);
            if (employee == null){
                employee = new Employee();
            }
            return View(employee);
        }

        [HttpPost]
        [ActionNameAttribute("Update")]
        public IActionResult UpdateConfirm(int id, Employee employee){
            if (employee == null){
                return View("Update", employee);
            }
            
            bool result = _employeeRes.EditById(id, employee);
            if (result)
            {
                return RedirectToAction("Detail", new {id = id});
            }

            return View("Update",employee);
        }
        public IActionResult Delete(int id){
            Employee employee = _employeeRes.GetById(id);
            return View(employee);
        }
        
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id, Employee employee){
            if (employee == null){
                ViewBag.message = "C?? l???i x???y ra";
                return View("Delete", employee);
            }
            bool result = _employeeRes.DeleteById(id);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}