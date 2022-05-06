using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DDTBaiTapLon486.Models;

namespace DDTBaiTapLon486.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AccountAdminController : Controller
    {
        private BtlDbContext db = new BtlDbContext();
        Encryption encryption = new Encryption();

        // GET: Admin/AccountAdmin
        public ActionResult Index()
        {
            var accounts = db.accounts.Include(a => a.Role);
            return View(accounts.ToList());
        }

        // GET: Admin/AccountAdmin/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Admin/AccountAdmin/Create
        public ActionResult Create()
        {
            ViewBag.RoleID = new SelectList(db.roles, "RoleID", "RoleName");
            return View();
        }

        // POST: Admin/AccountAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Username,Password,RoleID")] Account account)
        {
            if (ModelState.IsValid)
            {
                var passToMD5 = encryption.PasswordEncryption(account.Password);
                account.Password = passToMD5;
                db.accounts.Add(account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleID = new SelectList(db.roles, "RoleID", "RoleName", account.RoleID);
            return View(account);
        }

        // GET: Admin/AccountAdmin/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleID = new SelectList(db.roles, "RoleID", "RoleName", account.RoleID);
            return View(account);
        }

        // POST: Admin/AccountAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Username,Password,RoleID")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleID = new SelectList(db.roles, "RoleID", "RoleName", account.RoleID);
            return View(account);
        }

        // GET: Admin/AccountAdmin/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Admin/AccountAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Account account = db.accounts.Find(id);
            db.accounts.Remove(account);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
