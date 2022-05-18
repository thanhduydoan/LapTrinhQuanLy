using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DDTBaiThucHanh486.Models
{
    public class Product
    {
        [Key]
        public string ProductID { get; set; }

        public string ProductName { get; set; }
        [RegularExpression("^[1-9][0-9]+$", ErrorMessage = "Giá chỉ được là số và không bắt đầu bằng 0")]
        public float ProductPrice { get; set; }
        public string ProductDescription { get; set; }

        public string ProductImageName { get; set; }
        [NotMapped]
        public HttpPostedFileBase ProductImgFile { get; set; }
        public string CategoryID { get; set; }
        
    }
}