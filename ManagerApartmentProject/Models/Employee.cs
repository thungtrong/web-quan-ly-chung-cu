using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace ManagerApartmentProject.Models
{
    [Bind("id, name, address, email, phone_number, salary, join_date, position, description")]
    public class Employee
    {
        [DisplayName("ID")]
        public int ID { get; set; } = default(int);
        [DisplayName("id")]
        [DefaultValueAttribute("Đã xảy ra lỗi!")]

        public string name { get; set; }
        [DisplayName("Name")]
        public string address { get; set; }
        [DisplayName("Address")]
        public string email { get; set; }
        [DisplayName("Email")]
        
        public string phoneNumber { get; set; } 
        [DisplayName("Phone Number")]
        public int salary { get; set; }
        [DisplayName("Salary")]
        public DateTime join_date { get; set; } 
        [DisplayName("Join date")]

        public string position {get; set; }
        [DisplayName("Position")]

        public string description { get; set; }
        [DisplayName("Description")]

        public string creator { get; set; }
        

    }
}