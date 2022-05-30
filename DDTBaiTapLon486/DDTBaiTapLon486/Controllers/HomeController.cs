using DDTBaiTapLon486.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDTBaiTapLon486.Controllers
{
    public class HomeController : Controller
    {
        private BtlDbContext db = new BtlDbContext();
        public ActionResult Index()
        {
            return View(db.SanPhams.ToList());
        }
    }
}