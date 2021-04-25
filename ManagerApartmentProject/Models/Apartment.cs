using Microsoft.AspNetCore.Mvc;

namespace ManagerApartmentProject.Models
{
    [Bind("ID,name,floor,description,status,paymentPerMonth")]
    public class Apartment
    {
        public int ID { get; set; }
        public string name { get; set; }
        public int floor { get; set; }
        public string description { get; set; }
        public bool status { get; set; }
  
        public int paymentPerMonth { get; set; }
    }
}
