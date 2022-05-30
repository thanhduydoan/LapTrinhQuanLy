using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DDTBaiThucHanh486.Models
{
    
    public class SanPham
    {
        public SanPham()
        {
            Hinh = "~/Content/Images/2021-08-06.png";
        }
        [Key]
        public string SanPhamID { get; set; }
        public string TenSanPham { get; set; }
        public string SoLuong { get; set; }
        public string Hinh { get; set; }
        public int DonGia { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}