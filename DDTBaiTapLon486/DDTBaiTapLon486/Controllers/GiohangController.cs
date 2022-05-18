using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DDTBaiTapLon486.Models;

namespace DDTBaiTapLon486.Controllers
{
    public class GiohangController : Controller
    {
        private BtlDbContext db = new BtlDbContext();

        // GET: Giohang
        public ActionResult Index()
        {
            return View(db.giohangs.ToList());
        }

        // GET: Giohang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giohang giohang = db.giohangs.Find(id);
            if (giohang == null)
            {
                return HttpNotFound();
            }
            return View(giohang);
        }

        // GET: Giohang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Giohang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDonHang,TenDonHang,Tenkhachhang,NgayBan,DonGia,SoLuong,ThanhTien")] Giohang giohang)
        {
            if (ModelState.IsValid)
            {
                db.giohangs.Add(giohang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(giohang);
        }

        // GET: Giohang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giohang giohang = db.giohangs.Find(id);
            if (giohang == null)
            {
                return HttpNotFound();
            }
            return View(giohang);
        }

        // POST: Giohang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDonHang,TenDonHang,Tenkhachhang,NgayBan,DonGia,SoLuong,ThanhTien")] Giohang giohang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(giohang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(giohang);
        }

        // GET: Giohang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giohang giohang = db.giohangs.Find(id);
            if (giohang == null)
            {
                return HttpNotFound();
            }
            return View(giohang);
        }

        // POST: Giohang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Giohang giohang = db.giohangs.Find(id);
            db.giohangs.Remove(giohang);
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
