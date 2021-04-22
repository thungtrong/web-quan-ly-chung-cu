using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ManagerApartmentProject.Models{
    public class Notification {
        [DisplayName("ID")]
        public int ID { get; set; }
        [DisplayName("Tiêu Đề")]
        [Required(ErrorMessage = "Tiêu đề không được để trống")]
        public string title { get; set; }
        [DisplayName("Nội dung")]
        [Required(ErrorMessage = "Nội dung không được để trống")]
        public string content { get; set; }
        [DisplayName("Ngày đăng")]
        public DateTime dateRelease { get; set; }
        
        [DisplayName("Người tạo")]
        public string creator { get; set; }

        public Notification()
        {
            dateRelease = DateTime.Now;
        }
        
        public override string ToString(){
            return $"ID = {ID}\nTitle = {title}\n{content}";
        }
    }
}