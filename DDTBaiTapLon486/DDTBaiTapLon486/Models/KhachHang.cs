using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DDTBaiTapLon486.Models
{
    public class KhachHang
    {
            [Key]
            public string Makhachhang { get; set; }
            public string Tenkhachhang { get; set; }
            public int SDT { get; set; }
            public string Diachi { get; set; }
    }
}