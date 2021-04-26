using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using ManagerApartmentProject.Models;
using ManagerApartmentProject.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ManagerApartmentProject.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAccountRes _accountRes;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAccountRes accountRes, ILogger<AuthController> logger)
        {
            _accountRes = accountRes;
            _logger = logger;
        }
        public IActionResult Login()
        {
            return View(new Account());
        }

        [HttpPost, ActionName("Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginConfirmedAsync(Account account)
        {

            PersonModel info = GetInfoAsync(account);
            // _logger.LogInformation(info.ID, info.name, info.email, info.phoneNumber);
            _logger.LogInformation(account.password);
            if (info == null)
            {
                ViewBag.Error = true;
                return View(account);
            }

            await LogInAsyn(info);

            return RedirectToAction("Index", "Home");
        }

        private async Task LogInAsyn(PersonModel info)
        {
            List<Claim> authClaims = new List<Claim>(){
                new Claim(ClaimTypes.Name, info.name),
                new Claim(ClaimTypes.Email, info.email),
                new Claim(ClaimTypes.MobilePhone, info.phoneNumber)
            };

            var identity = new ClaimsIdentity(authClaims, "identity");
            var principal = new ClaimsPrincipal(new[] { identity });

            var signin = AuthenticationHttpContextExtensions.SignInAsync(HttpContext, principal);

            // Ghi lai ID cua nguoi su huu tai khoan
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddMinutes(120);
            Response.Cookies.Append("Id", info.ID.ToString(), cookieOptions);
            
            await signin;
        }
        private PersonModel GetInfoAsync(Account account)
        {
            if (account == null || account.authority > 3)
            {
                return null;
            }

            PersonModel task;
            if (account.authority <= 1)
            {
                task = _accountRes.GetPersonAdminByUserNamePassword(account);
                return task;
            }
            if (account.authority == 2)
            {
                task = _accountRes.GetPersonEmployeeByUserNamePassword(account);
                return task;
            }
            else
            {
                task = _accountRes.GetPersonTenantByUserNamePassword(account);
                return task;
            }
        }
    }
}