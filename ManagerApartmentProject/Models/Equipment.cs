using System;
using Microsoft.AspNetCore.Mvc;

namespace ManagerApartmentProject.Models
{
    [Bind("ID,name,count,equipmentOf")]
    public class Equipment

    {
        public int ID { get; set; }
        public String name { get; set; }
        public int count { get; set; }
        public int equipmentOf { get; set; }
    }
}
