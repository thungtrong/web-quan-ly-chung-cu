using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace ManagerApartmentProject.Models
{
    [Bind("id, name, address, email, phoneNumber, salary, joinDate, description")]
    public class Employee
    {
        public int ID { get; set; } = default(int);

        [DisplayName("Name")]
        public string name { get; set; }
        
        [DisplayName("Address")]
        public string address { get; set; }

        [DisplayName("Email")]

        public string email { get; set; }
        
        [DisplayName("Phone Number")]
        public string phoneNumber { get; set; } 

        [DisplayName("Salary")]
        public int salary { get; set; }

        [DisplayName("Join date")]
        public DateTime joinDate { get; set; } 

        [DisplayName("Description")]
        public string description { get; set; }
        

    }
}