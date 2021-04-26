using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ManagerApartmentProject.Models
{
    [Bind("id, name, address, email, phoneNumber, salary, joinDate, description")]
    public class Employee : PersonModel
    {
        [DisplayName("Address")]
        public string address { get; set; }

        [DisplayName("Salary")]
        public int salary { get; set; }

        [DisplayName("Join date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime joinDate { get; set; } 

        [DisplayName("Description")]
        public string description { get; set; }
        

    }
}