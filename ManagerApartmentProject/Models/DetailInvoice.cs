using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace ManagerApartmentProject.Models
{
    [Bind("ID,name,amount")]
    public class DetailInvoice
    {
        public int ID { get; set; }
        [DisplayName("Name")]
        public string name { get; set; }
        [DisplayName("Amount")]
        public int amount { get; set; }

    }
}