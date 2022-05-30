using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DDTBaiTapLon486.Models;

namespace DDTBaiTapLon486.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SanPhamController : Controller
    {
        private BtlDbContext db = new BtlDbContext();

        // GET: SanPham
        [AllowAnonymous]
        public ActionResult Index(string searchString)
        {
            var links = from l in db.SanPhams
                        select l;
            if (!String.IsNullOrEmpty(searchString))
            {
                var linksearch = links.Where(s => s.TenSanPham.ToLower().Contains(searchString.ToLower())).ToList();
                return View(linksearch);
            }
            var sanPhams = db.SanPhams.Include(s => s.Category).Include(s => s.NhaCungCap);
            return View(sanPhams.ToList());
        }

        // GET: SanPham/Details/5
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            return View(db.SanPhams.Where(s => s.SanPhamID == id).FirstOrDefault());
        }

        // GET: SanPham/Create
        public ActionResult Create()
        {
            SanPham sp = new SanPham();
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            ViewBag.MaNhaCungCap = new SelectList(db.nhaCungCaps, "MaNhaCungCap", "TenNhaCungCap");
            return View(sp);
        }

        // POST: SanPham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SanPham sp)
        {
            try
            {
                if (sp.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(sp.ImageUpload.FileName);
                    string extension = Path.GetExtension(sp.ImageUpload.FileName);
                    fileName = fileName + extension;
                    sp.Hinh = "~/Content/Images/" + fileName;
                    sp.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/Images/"), fileName));
                }
                db.SanPhams.Add(sp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [AllowAnonymous]
        // GET: SanPham/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", sanPham.CategoryID);
            ViewBag.MaNhaCungCap = new SelectList(db.nhaCungCaps, "MaNhaCungCap", "TenNhaCungCap", sanPham.MaNhaCungCap);
            return View(sanPham);
        }

        // POST: SanPham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sanphamid,Tensanpham,Gia,Soluong,Hinh,Motasanpham,MaNhaCungCap,CategoryID")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", sanPham.CategoryID);
            ViewBag.MaNhaCungCap = new SelectList(db.nhaCungCaps, "MaNhaCungCap", "TenNhaCungCap", sanPham.MaNhaCungCap);
            return View(sanPham);
        }

        // GET: SanPham/Delete/5
        [AllowAnonymous]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanPham);
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
