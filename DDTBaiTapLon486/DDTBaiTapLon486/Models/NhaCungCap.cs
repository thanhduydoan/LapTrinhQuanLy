using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DDTBaiTapLon486.Models
{
    public class NhaCungCap
    {
        [Key]
        public string MaNhaCungCap { get; set; }
        public string  TenNhaCungCap { get; set; }
        public ICollection<SanPham> SanPhams { get; set; }

    }
}