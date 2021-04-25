using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace ManagerApartmentProject.Models
{
    [Bind("ID,name,description")]
    public class Floor
    {
        public int ID { get; set; }
        [DisplayName("Name")]
        public String name { get; set; }
        [DisplayName("Description")]
        public String description { get; set; }
    }
}
