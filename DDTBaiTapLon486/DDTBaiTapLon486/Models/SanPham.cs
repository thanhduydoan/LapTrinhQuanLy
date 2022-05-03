using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DDTBaiTapLon486.Models
{
    public class SanPham
    {
        [Key]
        public int Sanphamid { get; set; }
        public string Tensanpham { get; set; }
        public float Gia { get; set; }
        public int Soluong { get; set; }
        public string MaNhaCungCap { get; set; }
        public NhaCungCap NhaCungCap { get; set; }
        

    }
}