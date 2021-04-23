using Microsoft.AspNetCore.Mvc;

namespace ManagerApartmentProject.Models
{
    [Bind("ID,name,amount")]
    public class DetailInvoice
    {
        public int ID { get; set; }
        public string name { get; set; }
        public int amount { get; set; }

    }
}