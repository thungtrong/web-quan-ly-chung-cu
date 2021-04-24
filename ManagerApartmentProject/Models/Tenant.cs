using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace ManagerApartmentProject.Models
{
    [Bind("title,amount,dateCreate,status,description")]
    public class Tenant
    {
        [DisplayName("ID")]
        public int ID { get; set; } = default(int);
        [DisplayName("id")]
        [DefaultValueAttribute("Đã xảy ra lỗi!")]
        public string name { get; set; }
        [DisplayName("Name")]
        public string email { get; set; }
        [DisplayName("Email")]
        
        public string phoneNumber { get; set; }
        [DisplayName("Phone Number")]
        public int advancePayment { get; set; }
        [DisplayName("Advance Payment")]
        public int paymentPerMonth { get; set; }
        [DisplayName("Payment Per Month")]

        public int status { get; set; }
        [DisplayName("Status")]

        public string unitNo { get; set; }
        [DisplayName("Unit No")]
        public string creator { get; set; }

    }
}