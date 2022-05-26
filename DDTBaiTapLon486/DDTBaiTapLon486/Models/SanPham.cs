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
        public int SanPhamID { get; set; }
        public string Tensanpham { get; set; }
        public int Gia { get; set; }
        public int Soluong { get; set; }
        public string Hinh { get; set; }
        public string Motasanpham { get; set; }
        public string MaNhaCungCap { get; set; }
        public NhaCungCap NhaCungCap { get; set; }
        public string CategoryID { get; set; }
        public Category Category { get; set; }
        public ICollection<Giohang> Giohangs { get; set; }


    }
}