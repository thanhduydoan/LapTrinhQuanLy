using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DDTBaiThucHanh486.Models
{
    public class Person
    {
        [Key]
        public int id { get; set; }
        public string PersonName { get; set; }
    }
}