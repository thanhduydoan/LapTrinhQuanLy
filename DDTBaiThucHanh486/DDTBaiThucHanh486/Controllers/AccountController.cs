using DDTBaiThucHanh486.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DDTBaiThucHanh486.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        Encryption encryption = new Encryption();
        Model1 db = new Model1();

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Account account)
        {
            try {
                if (ModelState.IsValid)
                {
                    account.Password = encryption.PasswordEncryption(account.Password);
                    db.Accounts.Add(account);
                    db.SaveChanges();
                    return RedirectToAction("Login", "Account");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Tài khoản đã tồn tại");
            }
            
            return View(account);
        }
        // GET: Account
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (CheckSession() == 1)
            {
                return RedirectToAction("Index", "Admin", new { Area = "Admin" });
            }
            else if (CheckSession() == 2)
            {
                return RedirectToAction("Index", "User", new { Area = "User" });
            }
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Account acc, string returnUrl)
        {
            try
            {
                if (!string.IsNullOrEmpty(acc.Username) && !string.IsNullOrEmpty(acc.Password))
                {
                    using (var db = new Model1())
                    {
                        var passToMD5 = encryption.PasswordEncryption(acc.Password);
                        var account = db.Accounts.Where(a => a.Username.Equals(acc.Username) && a.Password.Equals(passToMD5)).Count();
                        if (account == 1)
                        {
                            FormsAuthentication.GetAuthCookie(acc.Username, false);//Luu trang thai dang nhap
                            Session["idUser"] = acc.Username;
                            Session["roleUser"] = acc.RoleID;
                            return RedirectToAction(returnUrl);
                        }
                        ModelState.AddModelError("", "Thông tin đăng nhập sai");
                    }
                }
                ModelState.AddModelError("", "Nhập cả username và password");
            }
            catch
            {
                ModelState.AddModelError("", "Hệ thống đang bảo trì vui lòng liên hệ với quản trị viên");
            }
            return View(acc);
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["idUser"] = null;
            return RedirectToAction("Login", "Account");
        }
        private int CheckSession()//Kiểm tra quyền đăng nhập
        {
            using (var db = new Model1())
            {
                var user = HttpContext.Session["idUser"];
                if (user != null)
                {
                    var role = db.Accounts.Find(user.ToString()).RoleID;
                    if (role.ToString() == "1")
                    {
                        return 1;
                    }
                    else if (role.ToString() == "2")
                    {
                        return 2;
                    }

                }
            }
            return 0;
        }
        private ActionResult RedirectToLocal(string returnUrl)//Kiem tra URL co thuoc he thong khong
        {
            if (string.IsNullOrEmpty(returnUrl) || returnUrl == "/")
            {
                if (CheckSession() == 1)
                {
                    return RedirectToAction("Index", "Admin", new { Areas = "Admin" });
                }
                else if (CheckSession() == 2)
                {
                    return RedirectToAction("Index", "User", new { Areas = "User" });
                }
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}