using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace ManagerApartmentProject.Models
{
    [Bind("id, name, email, phoneNumber, advancePayment")]
    public class Tenant
    {
        [DisplayName("ID")]
        public int ID { get; set; } = default(int);
        [DefaultValueAttribute("Đã xảy ra lỗi!")]

        [DisplayName("Name")]
        public string name { get; set; }

        [DisplayName("Email")]
        public string email { get; set; }       
        
        [DisplayName("Phone Number")]
        public string phoneNumber { get; set; }       

        [DisplayName("Advance Payment")]
        public int advancePayment { get; set; }

        
    }
}