using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace ManagerApartmentProject.Models
{
    [Bind("title,amount,dateCreate,status,description")]
    public class Tenant
    {
        [DisplayName("ID")]
        public int ID { get; set; } = default(int);
        [DisplayName("Title")]
        [DefaultValueAttribute("Đã xảy ra lỗi!")]
        public string title { get; set; }
        [DisplayName("Amount")]
        public int amount { get; set; } = default(int);
        [DisplayName("Create Time")]
        
        public DateTime dateCreate { get; set; } = DateTime.Now;
        [DisplayName("Status")]
        public int status { get; set; }
        [DisplayName("Description")]
        public string description { get; set; }
        [DisplayName("Creator")]
        public string creator { get; set; }

    }
}