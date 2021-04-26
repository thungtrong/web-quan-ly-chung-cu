using System;
using System.Security.Cryptography;
using System.Text;
using ManagerApartmentProject.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ManagerApartmentProject.Models
{
    [Bind("username,password,authority")]
    public class Account
    {
        public string username { get; set; }
        public string password { get; set; }
        //
        // 0 : Super Admin
        // 1 : Admin
        // 2 : Employye
        // 3 : Tenant
        public int authority { get; set; }

    }
}