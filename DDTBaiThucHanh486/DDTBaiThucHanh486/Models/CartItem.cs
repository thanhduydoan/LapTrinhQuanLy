using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DDTBaiThucHanh486.Models
{
    [Serializable]
    public class CartItem
    {
        [Key]
        public int Quantity { get; set; }
        public SanPham SanPham { get; set; }
    }
}