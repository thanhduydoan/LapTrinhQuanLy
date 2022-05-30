using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DDTBaiTapLon486.Models
{
    public class SanPham
    {
        public SanPham()
        {
            Hinh = "~/Content/Images/add-icon.jpg";
        }
        [Key]
        public int SanPhamID { get; set; }
        public string TenSanPham { get; set; }
        public string SoLuong { get; set; }
        public string Hinh { get; set; }
        public int DonGia { get; set; }
        public string Motasanpham { get; set; }
        public string MaNhaCungCap { get; set; }
        public NhaCungCap NhaCungCap { get; set; }
        public string CategoryID { get; set; }
        public Category Category { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}