using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace ManagerApartmentProject.Models
{
    [Bind("title,amount,dateCreate,status,description")]
    public class Admin
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
        public int status { get; set; }
        [DisplayName("Status")]
        public string description { get; set; }
        [DisplayName("Description")]
        public string creator { get; set; }

    }
}