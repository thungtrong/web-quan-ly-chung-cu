using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using CAIT.SQLHelper;
using ManagerApartmentProject.Const;
using ManagerApartmentProject.Models;
using ManagerApartmentProject.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Policy = "AdminOrGreater")]
        public IActionResult Register()
        {
            Account account = new Account();
            if (TempData["account"] != null)
            {
                string tmp = Convert.ToString(TempData["account"]);
                account = JsonSerializer.Deserialize<Account>(tmp);
                
            }
            List<PersonModel> persons = GetPersonDontHaveAccount(account.authority);
            ViewBag.personList = persons;
            
            account.accountOf = persons.Count > 0 ? persons[persons.Count - 1].ID : 0;
            
            return View(account);
        }

        [Authorize(Policy = "AdminOrGreater")]
        public IActionResult RegisterConfirm(Account account)
        {
            bool result = _accountRes.CreateAccount(account);
            
            if (result)
            {
                if (account.authority == 1)
                {
                    return RedirectToAction("Index", "Home");
                }
                if (account.authority == 2)
                {
                    return RedirectToAction("Index", "Employee");
                }
                if (account.authority == 3)
                {
                    return RedirectToAction("Index", "Tenant");
                }
            }
            
            TempData["account"] = JsonSerializer.Serialize(account);

            return RedirectToAction("Register", "Auth");
        }

        [Authorize(Policy = "AdminOrGreater")]
        [Route("[controller]/GetPersonDontHaveAccountApi/{authority}")]
        public string GetPersonDontHaveAccountApi(int authority)
        {
            List<PersonModel> lst;
            if (authority > 0)
            {
                lst = GetPersonDontHaveAccount(authority);
            }
            else
            {
                lst = new List<PersonModel>();
            }

            return JsonSerializer.Serialize(lst);
        }

        private List<PersonModel> GetPersonDontHaveAccount(int authority)
        {
            List<PersonModel> lst = new List<PersonModel>();
            // Admin
            if (authority == 1)
            {
                lst = DataProvider.GetListFrom<PersonModel>(
                    "GetAdminDontHaveAccount",
                    null,
                    (DataRow row) => SQLCommand.Map<PersonModel>(row)
                );
            }
            // Employee
            if (authority == 2)
            {
                lst = DataProvider.GetListFrom<PersonModel>(
                    "GetEmployeeDontHaveAccount",
                    null,
                    (DataRow row) => SQLCommand.Map<PersonModel>(row)
                );
            }
            // Tenant
            if (authority == 3)
            {
                lst = DataProvider.GetListFrom<PersonModel>(
                    "GetTenantDontHaveAccount",
                    null,
                    (DataRow row) => SQLCommand.Map<PersonModel>(row)
                );
            }
            return lst;
        }

        [HttpPost, ActionName("Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginConfirmedAsync(Account account)
        {
            PersonModel info = await GetInfo(account);
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


        public IActionResult RePassword()
        {
            Account account = new Account{
                accountOf = Convert.ToInt32(User.FindFirst("Id").Value)
            };
            return View(account);
        }

        [HttpPost, ActionName("RePassword")]
        [ValidateAntiForgeryToken]
        public IActionResult RePasswordConfirm(Account account)
        {
            if (User.IsInRole("SuperAdmin"))
            {
                account.authority = 0;
            }

            if (User.IsInRole("Admin"))
            {
                account.authority = 1;
            }

            if (User.IsInRole("Employee"))
            {
                account.authority = 2;
            }

            if (User.IsInRole("Tenant"))
            {
                account.authority = 3;
            }
            bool result = _accountRes.RePassword(account);
            if (result)
            {
                return RedirectToAction("Index", "Home");
            }
            account = new Account();
            return View();
        }


    }
}