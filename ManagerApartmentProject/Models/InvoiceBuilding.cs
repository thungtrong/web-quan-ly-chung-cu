using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ManagerApartmentProject.Models{
    public class InvoiceBuilding {
        public int ID { get; set; }
        [DisplayName("Title")]
        public string title { get; set; }
        [DisplayName("Date Create")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime dateCreate { get; set; }
        [DisplayName("Amount")]
        public int amount { get; set; }
        [DisplayName("Status")]
        public bool status { get; set; }
        [DisplayName("Description")]
        public string description { get; set; }
        [DisplayName("Creator")]
        public string creator { get; set; }
    }
}