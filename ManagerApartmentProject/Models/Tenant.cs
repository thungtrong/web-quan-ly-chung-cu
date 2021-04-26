using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace ManagerApartmentProject.Models
{
    [Bind("id, name, email, phoneNumber, advancePayment")]
    public class Tenant : PersonModel
    {
        [DisplayName("Advance Payment")]
        public int advancePayment { get; set; }
    }
}