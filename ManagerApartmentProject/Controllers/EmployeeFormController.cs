using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ManagerApartmentProject.Repositories;
using ManagerApartmentProject.Models;
using ManagerApartmentProject;
using Microsoft.AspNetCore.Authorization;

namespace ManagerAparmentProject.Controllers
{

    public class EmployeeFormController : Controller
    {

        private readonly IEmployeeFormRes _employeeformRes;
        public EmployeeFormController(IEmployeeFormRes employeeformRes){
            _employeeformRes = employeeformRes;
        }

        // GET: Complaint 
        public IActionResult Index()
        {
            var _creator = int.Parse(User.FindFirst("Id").Value);

            var lstform= _employeeformRes.EmployeeForm_GetAll();
            if (User.IsInRole("Employee"))
            {
                lstform = _employeeformRes.EmployeeForm_GetAll_ById(_creator);
            }
            return View(lstform);
        }

        // GET: Complaint/Detail
        public IActionResult Detail(int id)
        {

               EmployeeForm employeeform = _employeeformRes.EmployeeForm_GetById(id);
               return View(employeeform);
           
        }
        // GET
        public IActionResult Update(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            EmployeeForm UpdateForm = _employeeformRes.EmployeeForm_GetById(id);

            return View(UpdateForm);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, EmployeeForm employeeform)
        {

            var result = _employeeformRes.UpdateById(id, employeeform);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(employeeform);
            }

        }

        // GET: Complaint/Create

        public IActionResult Create()
        {
            var employeeform = new EmployeeForm();

            return View(employeeform);
        }

        // POST: Complaint/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeForm employeeform)
        {
            try
            {
                var _creator = int.Parse(User.FindFirst("Id").Value);
                bool result = _employeeformRes.EmployeeForm_Insert(employeeform, _creator);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(employeeform);
                }

            }
            catch
            {
                return View();
            }
        }


        // GET: Floor/Delete/5
        [Authorize(Policy = "Employee")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            EmployeeForm DelEmployeeForm = _employeeformRes.EmployeeForm_GetById(id);

            return View(DelEmployeeForm);
        }


        // POST: Floor/Delete/5
        [Authorize(Policy = "Employee")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id, EmployeeForm employeeform)
        {
            if (employeeform == null)
            {
                ViewBag.message = "Có lỗi xảy ra";
                return View("Delete", employeeform);
            }
            bool result=true;
            if(User.IsInRole("Employee")){
                result = _employeeformRes.EmployeeForm_DeleteByID(id);
            }
            
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
