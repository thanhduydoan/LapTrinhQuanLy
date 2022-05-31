using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDTBaiTapLon486.Models
{
    public class OrderDetail
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int SanPhamID { get; set; }
        public decimal UnitPriceSale { get; set; }
        public int QuantitySale { get; set; }

    }
}