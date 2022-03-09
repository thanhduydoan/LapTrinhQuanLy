using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DDTBaiTapLon486.Models
{
    public class Role
    {
        [Key]
        [StringLength(10)]
        public string Roleid { get; set; }
        [StringLength(30)]
        public string Rolename { get; set; }
    }
}