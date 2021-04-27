using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ManagerApartmentProject.Const
{
    public class ConstValue
    {
        public static string ConnectionString;

        public static string[] Roles { get; } = { "SuperAdmin", "Admin", "Employee", "Tenant"};
    }
}
