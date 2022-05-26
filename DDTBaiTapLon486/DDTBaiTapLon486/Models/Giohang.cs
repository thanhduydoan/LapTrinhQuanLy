using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DDTBaiTapLon486.Models
{
    public class Giohang
    {
        [Key]

        public string Hinh { get; set; }
        public int SanPhamID { get; set; }
        public string Tensanpham { get; set; }
        [ForeignKey("SanPhamID")]
        public SanPham SanPham { get; set; }
        public int DonGia { get; set; }
        public int SoLuong { get; set; }
        public int ThanhTien
        {
            get
            {
                return SoLuong * DonGia;
            }
        }
    }
}