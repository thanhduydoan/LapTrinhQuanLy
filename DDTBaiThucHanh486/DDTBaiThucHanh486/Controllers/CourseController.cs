using DDTBaiThucHanh486.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDTBaiThucHanh486.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            using (var context = new Model1())
            {
                // you must provide the unique CourseId value
                var maths = new Course() { CourseId = 1, CourseName = "Maths" };
                context.Courses.Add(maths);

                // you must provide the unique CourseId value
                var eng = new Course() { CourseId = 2, CourseName = "English" };
                context.Courses.Add(eng);

                // the following will throw an exception as CourseId has duplicate value
                //var sci = new Course(){ CourseId=2,  CourseName="sci"};

                context.SaveChanges();
            }
            return View();
        }
    }
}