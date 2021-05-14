using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ManagerApartmentProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using ManagerApartmentProject.Repositories;
using System;

namespace ManagerApartmentProject.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(
            ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        
        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult Profile()
        {
            int id = Convert.ToInt32(User.FindFirst("ID").Value);
            if (User.IsInRole("SuperAdmin") || User.IsInRole("Admin"))
            {
                IAdminRes adminRes = new AdminRes();
                PersonModel person = adminRes.GetAdminById(id);
                
                return View(person);
            }

            if (User.IsInRole("Employee"))
            {
                IEmployeeRes employeeRes = new EmployeeRes();
                Employee person = employeeRes.GetById(id);
                
                return View(person);
            }
            
            ITenantRes tenantRes = new TenantRes();
            Tenant person_1 = tenantRes.GetById(id);
        
            return View(person_1);
            
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
