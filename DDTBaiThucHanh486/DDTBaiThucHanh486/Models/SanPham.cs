using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DDTBaiThucHanh486.Models
{
    public class SanPham
    {
        [Key]
        public string SanPhamID { get; set; }
        public string TenSanPham { get; set; }
        public string SoLuong { get; set; }
        public string Hinh { get; set; }
        public int DonGia { get; set; }
    }
}