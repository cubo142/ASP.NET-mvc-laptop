using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Selling_Laptop.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }

        [Required(ErrorMessage ="Cần nhập số điện thoại")]
        public string SDT { get; set; }

        [Required(ErrorMessage = "Cần nhập mật khẩu")]
        public string Password { get; set; }

    }
}