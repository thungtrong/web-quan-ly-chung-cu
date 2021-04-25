using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace ManagerApartmentProject.Models
{
    [Bind("ID,name,count,equipmentOf,apartmentName")]
    public class Equipment

    {
        public int ID { get; set; }
        [DisplayName("Name")]
        public String name { get; set; }
        [DisplayName("Quantily")]
        public int count { get; set; }
        [DisplayName("Apartment")]
        public int equipmentOf { get; set; }
        [DisplayName("Apartment")]
        public string apartmentName { get; set; }
    }
}
