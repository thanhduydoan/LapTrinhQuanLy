using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DDTBaiTapLon486.Models
{
    public class Giohang
    {
        [Key]
        public int MaDonHang { get; set; }
        public string TenDonHang { get; set; }
        public string Tenkhachhang { get; set; }
        public KhachHang KhachHang { get; set; }
    }
}