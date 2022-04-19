using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDTBaiTapLon486.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    public class UserController : Controller
    {
        // GET: User/User
        public ActionResult Index()
        {
            return View();
        }
    }
}