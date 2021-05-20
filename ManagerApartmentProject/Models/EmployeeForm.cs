using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ManagerApartmentProject.Models
{
	[Bind("ID,title,content,dateRelease,creator,status")]
	public class EmployeeForm
	{
        [DisplayName("ID")]
        public int ID { get; set; }
        [DisplayName("Loại đơn")]
        [Required(ErrorMessage = "Không được để trống")]
        public string title { get; set; }
        [DisplayName("Nội dung")]
        [Required(ErrorMessage = "Nội dung không được để trống")]
        public string content { get; set; }
        [DisplayName("Ngày tạo")]
        public DateTime dateRelease { get; set; }
         
        [DisplayName("Nhân viên")]
        public string creator { get; set; }
        [DisplayName("Trạng Thái")]
        public string status { get; set; }
        public EmployeeForm()
        {
            dateRelease = DateTime.Now;
            status = "0";
         }

        public override string ToString()
        {
            return $"ID = {ID}\nTitle = {title}\n{content}";
        }
    }
}