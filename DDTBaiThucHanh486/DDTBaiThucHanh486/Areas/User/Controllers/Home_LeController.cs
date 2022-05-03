using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDTBaiThucHanh486.Areas.User.Controllers
{[Authorize]
    public class Home_LeController : Controller
    {
        // GET: User/Home_Le
        public ActionResult Index()
        {
            return View();
        }
    }
}