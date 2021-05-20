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

    public class ComplaintController : Controller
    {

        private readonly IComplaintRes _complaintRes;
        public ComplaintController(IComplaintRes complaintRes){
            _complaintRes = complaintRes;
        }

        // GET: Complaint 
        public IActionResult Index()
        {
            var _creator = int.Parse(User.FindFirst("Id").Value);

            var lstComplaint = _complaintRes.Complaint_GetAll();
            if (User.IsInRole("Employee"))
            {
                lstComplaint = _complaintRes.Complaint_Employee_GetAll(_creator);
            }
            if (User.IsInRole("Tenant"))
            {
                lstComplaint = _complaintRes.Complaint_Tenant_GetAll(_creator);
            }
            return View(lstComplaint);
        }

        // GET: Complaint/Detail
        public IActionResult Detail(int id)
        {

                Complaint complaint = _complaintRes.Complaint_Employee_GetById(id);
                if (complaint != null) { 
                    return View(complaint);
                }
                complaint = _complaintRes.Complaint_Tenant_GetById(id);
               return View(complaint);
           
        }

        // GET: Complaint/Create
        [Authorize(Policy = "EmployeeOrTenant")]
        public IActionResult Create()
        {
            var complaint = new Complaint();

            return View(complaint);
        }

        // POST: Complaint/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        [Authorize(Policy = "EmployeeOrTenant")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Complaint complaint)
        {
            try
            {
                var _creator = int.Parse(User.FindFirst("Id").Value);
                var result = true;
                if (User.IsInRole("Employee"))
                {
                    result = _complaintRes.Complaint_Employee_Insert(complaint, _creator);
                }
                if (User.IsInRole("Tenant"))
                {
                    result = _complaintRes.Complaint_Tenant_Insert(complaint, _creator);
                }
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(complaint);
                }

            }
            catch
            {
                return View();
            }
        }


        // GET: Floor/Delete/5
        [Authorize(Policy = "EmployeeOrTenant")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            Complaint DelComplaint = _complaintRes.Complaint_Employee_GetById(id);
            if (User.IsInRole("Tenant"))
            {
                DelComplaint = _complaintRes.Complaint_Tenant_GetById(id);
            }

            return View(DelComplaint);
        }


        // POST: Floor/Delete/5
        [Authorize(Policy = "EmployeeOrTenant")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id, Complaint complaint)
        {
            if (complaint == null)
            {
                ViewBag.message = "Có lỗi xảy ra";
                return View("Delete", complaint);
            }
            bool result=true;
            if(User.IsInRole("Tenant")){
                result = _complaintRes.Complaint_Tenant_DeleteByID(id);
            }
            if(User.IsInRole("Employee")){
                result = _complaintRes.Complaint_Employee_DeleteByID(id);
            }
            
            if (result)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
