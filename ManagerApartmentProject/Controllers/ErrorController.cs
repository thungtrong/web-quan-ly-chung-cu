using System;
using Microsoft.AspNetCore.Mvc;

namespace ManagerApartmentProject.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{code}")]
        public IActionResult ErrorPage(int code)
        {
            ViewBag.statusCode = code;
            return View();
        }
    }
}