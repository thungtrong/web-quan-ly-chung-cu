using Microsoft.AspNetCore.Mvc;

namespace ManagerApartmentProject.Models
{
    [Bind("ID,name")]
    public class ApartmentModel
    {
        public int ID { get; set; }
        public string name { get; set; }
    }
}