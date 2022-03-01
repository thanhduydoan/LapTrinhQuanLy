using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDTBaiThucHanh486.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string MaSinhVien, string TenSinhVien)
        {
            ViewBag.Message = MaSinhVien;
            ViewBag.Message = TenSinhVien;
            return View();
        }
    }
}