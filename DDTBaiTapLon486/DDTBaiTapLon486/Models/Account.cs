using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DDTBaiTapLon486.Models
{
    public class Account
    {
        [Key]
        [Required(ErrorMessage ="Tên người dùng không được để trống")]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Mật khẩu không được để trống")]
        public string Password { get; set; }
        [Required]
        public string RoleID { get; set; }
        public Role Role { get; set; }
    }
}