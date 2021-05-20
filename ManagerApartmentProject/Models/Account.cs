using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using ManagerApartmentProject.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ManagerApartmentProject.Models
{
    [Bind("username,password,newPassword,authority,accountOf")]
    public class Account
    {

        [Required(ErrorMessage = "Tên tài khoản không được để trống")]
        public string username { get; set; }
        
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string password { get; set; }

        [Required(ErrorMessage = "Mật khẩu mới không được để trống")]
        public string newPassword { get; set; }
        //
        // 0 : Super Admin
        // 1 : Admin
        // 2 : Employye
        // 3 : Tenant
        [Required(ErrorMessage = "Chọn loại tài khoản")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Chọn loại tài khoản")]
        public int authority { get; set; }

        [Required(ErrorMessage = "Chọn người sỡ hữu tài khoản")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Chọn người sỡ hữu tài khoản")]
        public int accountOf { get; set; }
    }
}