using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace ManagerApartmentProject.Models{
    [Bind("ID,dateRelease,datePaid,status,owner,amount")]
    public class InvoiceApartment{
        public int ID { get; set; }
        [DisplayName("Date Release")]
        public DateTime dateRelease { get; set; } = DateTime.Now;
        [DisplayName("Date Paid")]
        public DateTime datePaid { get; set; }
        [DisplayName("Status")]
        public bool status { get; set; }
        [DisplayName("Owner")]
        public string owner { get; set;}
        [DisplayName("Amount")]
        public int amount { get; set; } = 0;
    }
}