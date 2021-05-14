using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using ManagerApartmentProject.Const;
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

        public IActionResult Logout()
        {
            foreach (var cookie in Request.Cookies.Keys)
            {
                Console.WriteLine(cookie);
                if (cookie.Contains("AuthCookie"))
                {
                    Response.Cookies.Delete(cookie);
                }
            }
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        [HttpPost, ActionName("Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginConfirmedAsync(Account account)
        {
            PersonModel info = await GetInfo(account);
            // _logger.LogInformation(info.ID, info.name, info.email, info.phoneNumber);
            if (info == null)
            {
                ViewBag.Error = true;
                return View(account);
            }

            await LogInAsyn(info, account.authority);

            return RedirectToAction("Index", "Home");
        }

        private async Task LogInAsyn(PersonModel info, int authority)
        {
            List<Claim> authClaims = new List<Claim>(){
                new Claim(ClaimTypes.Name, info.name),
                new Claim(ClaimTypes.Email, info.email),
                new Claim(ClaimTypes.MobilePhone, info.phoneNumber),
                new Claim("Id", info.ID.ToString()),
            };

            List<Claim> roleClaims = new List<Claim>(){
                new Claim(ClaimTypes.Role, ConstValue.Roles[authority])
            };

            var identity = new ClaimsIdentity(authClaims, "identity");
            var role = new ClaimsIdentity(roleClaims, "role");
            var principal = new ClaimsPrincipal(new[] { identity, role });

            var signin = AuthenticationHttpContextExtensions.SignInAsync(HttpContext, principal);

            // Ghi lai ID cua nguoi su huu tai khoan
            // CookieOptions cookieOptions = new CookieOptions();
            // cookieOptions.Expires = DateTime.Now.AddMinutes(120);
            // Response.Cookies.Append("Id", info.ID.ToString(), cookieOptions);
            
            await signin;
        }
        private async Task<PersonModel> GetInfo(Account account)
        {
            if (account == null || account.authority > 3)
            {
                return null;
            }

            PersonModel task;
            if (account.authority <= 1)
            {
                task = await Task.Run(() => _accountRes.GetPersonAdminByUserNamePassword(account));
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