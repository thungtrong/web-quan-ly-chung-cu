using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ManagerApartmentProject.Const
{
    public class ConstValue
    {
        public static string ConnectionString;

        public static string[] Roles { get; } = { "SuperAdmin", "Admin", "Employee", "Tenant"};

        public static string[] Unicode { get; } = {
            " ",
            "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",  
            "đ",  
            "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",  
            "í","ì","ỉ","ĩ","ị",  
            "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",  
            "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",  
            "ý","ỳ","ỷ","ỹ","ỵ"
        };

        public static string[] NonUnicode { get; } = {
            "",
            "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",  
            "d",  
            "e","e","e","e","e","e","e","e","e","e","e",  
            "i","i","i","i","i",  
            "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",  
            "u","u","u","u","u","u","u","u","u","u","u",  
            "y","y","y","y","y"
        };

        public static string RemoveUnicode(string input)
        {
            if (input == null)
            {
                return "";
            }
            input = input.ToLower();
            for (int i = 0; i < Unicode.Length; i++)
            {
                input = input.Replace(Unicode[i], NonUnicode[i]);
            }
            return input;
        }
    }
}
