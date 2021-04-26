using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace ManagerApartmentProject.Models{
    [Bind("ID,dateRelease,datePaid,status,invoiceOf,amount,")]
    public class InvoiceApartment{
        public int ID { get; set; }
        [DisplayName("Date Release")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime dateRelease { set;get; } = DateTime.Now;
        [DisplayName("Date Paid")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime datePaid { get; set; }
        [DisplayName("Status")]
        public bool status { get; set; }
        [DisplayName("Tenant")]
        public string owner { get; set;}
        [DisplayName("Amount")]
        public int amount { get; set; } = 0;
        [DisplayName("Tenant")]
        public int invoiceOf { get; set; }

    }
}