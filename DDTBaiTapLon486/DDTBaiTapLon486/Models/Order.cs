using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDTBaiTapLon486.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string CodeCustomer { get; set; }
        public string Description { get; set; }
        public string OrderDetail { get; set; }
    }
}