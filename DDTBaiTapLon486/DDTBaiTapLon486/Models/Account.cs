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
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [StringLength(30)]
        public string Password { get; set; }
        [StringLength(10)]
        public string RoleID { get; set; }
        public Role Role { get; set; }
    }
}