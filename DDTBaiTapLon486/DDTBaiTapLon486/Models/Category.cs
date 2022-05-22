using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DDTBaiTapLon486.Models
{
    public class Category
    {
        [Key]
        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<SanPham> SanPhams { get; set; }
    }
}