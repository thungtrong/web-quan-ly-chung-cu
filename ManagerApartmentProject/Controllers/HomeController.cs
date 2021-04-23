using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ManagerApartmentProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace ManagerApartmentProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Privacy()
        {
            
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            var authClaims = new List<Claim>(){
                new Claim(ClaimTypes.Name, "Tran Hung Trong"),
                new Claim(ClaimTypes.Email, "tmp@gmail.com"),
            };

            var identity = new ClaimsIdentity(authClaims, "identity");
            var principal = new ClaimsPrincipal(new[] { identity});

            await AuthenticationHttpContextExtensions.SignInAsync(HttpContext, principal);
            
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddMinutes(120);
            Response.Cookies.Append("Id", "1", cookieOptions);

            return RedirectToAction("Privacy");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
