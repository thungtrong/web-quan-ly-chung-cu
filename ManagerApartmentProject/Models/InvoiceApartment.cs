using System;

namespace ManagerApartmentProject.Models{
    public class InvoiceApartment{
        public int ID { get; set; }
        public DateTime dateRelease { get; set; }
        public DateTime datePaid { get; set; }
        public bool status { get; set; }
        public string owner { get; set;}
    }
}