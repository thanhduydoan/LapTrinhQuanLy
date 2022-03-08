using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DDTBaiThucHanh486.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        public string EmployeeName { get; set; }
    }
}