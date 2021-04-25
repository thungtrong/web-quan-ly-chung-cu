using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace ManagerApartmentProject.Models
{
    [Bind("ID,name,floor,description,status,paymentPerMonth,floorName")]
    public class Apartment
    {
        public int ID { get; set; }
        [DisplayName("Name")]
        public string name { get; set; }
        [DisplayName("Floor")]
        public int floor { get; set; }
        [DisplayName("Description")]
        public string description { get; set; }
        [DisplayName("Status")]
        public bool status { get; set; }  
        [DisplayName("Payment")]
        public int paymentPerMonth { get; set; }
        [DisplayName("Floor")]
        public string floorName { get; set; }
    }
}
