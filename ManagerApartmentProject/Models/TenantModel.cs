using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace ManagerApartmentProject.Models
{
    public class TenantModel
    {
        public int ID { get; set; } = default(int);
        public string name { get; set; } = default(string);

    }
}