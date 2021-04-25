using System;
using Microsoft.AspNetCore.Mvc;

namespace ManagerApartmentProject.Models
{
    [Bind("ID,name,description")]
    public class Floor
    {
        public int ID { get; set; }
        public String name { get; set; }
        public String description { get; set; }
    }
}
