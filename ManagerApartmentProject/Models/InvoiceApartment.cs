using System;
using Microsoft.AspNetCore.Mvc;

namespace ManagerApartmentProject.Models{
    [Bind("ID,dateRelease,datePaid,status,owner")]
    public class InvoiceApartment{
        public int ID { get; set; }
        public DateTime dateRelease { get; set; } = DateTime.Now;
        public DateTime datePaid { get; set; }
        public bool status { get; set; }
        public string owner { get; set;}
        public int amount { get; set; } = 0;
    }
}