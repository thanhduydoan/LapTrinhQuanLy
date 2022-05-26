using DDTBaiTapLon486.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDTBaiTapLon486.Controllers
{
    public class GiohangController : Controller
    {
        // GET: Giohang
        private BtlDbContext db = new BtlDbContext();
        // GET: Giohang
        public ActionResult Index()
        {
            List<Giohang> giohang = Session["giohang"] as List<Giohang>;
            return View(giohang);
        }
        public RedirectToRouteResult ThemVaoGio(int SanPhamID)
        {
            if (Session["giohang"] == null) // Nếu giỏ hàng chưa được khởi tạo
            {
                Session["giohang"] = new List<Giohang>();  // Khởi tạo Session["giohang"] là 1 List<CartItem>
            }

            List<Giohang> giohang = Session["giohang"] as List<Giohang>;  // Gán qua biến giohang 

            // Kiểm tra xem sản phẩm khách đang chọn đã có trong giỏ hàng chưa

            if (giohang.FirstOrDefault(m => m.SanPhamID == SanPhamID) == null)
            {
                SanPham sp = db.SanPhams.Find(SanPhamID);  // tim sp theo sanPhamID

                Giohang newItem = new Giohang()
                {
                    SanPhamID = SanPhamID,
                    Tensanpham = sp.Tensanpham,
                    SoLuong = 1,
                    Hinh = sp.Hinh,
                    DonGia = sp.Gia

                };  // Tạo ra 1 CartItem mới

                giohang.Add(newItem);  // Thêm CartItem vào giỏ 
            }
            else
            {
                // Nếu sản phẩm khách chọn đã có trong giỏ hàng thì không thêm vào giỏ nữa mà tăng số lượng lên.
                Giohang cardItem = giohang.FirstOrDefault(m => m.SanPhamID == SanPhamID);
                cardItem.SoLuong++;
            }

            // Action này sẽ chuyển hướng về trang chi tiết sp khi khách hàng đặt vào giỏ thành công. Bạn có thể chuyển về chính trang khách hàng vừa đứng bằng lệnh return Redirect(Request.UrlReferrer.ToString()); nếu muốn.
            return RedirectToAction("Details", "SanPham", new { id = SanPhamID });
        }
        public RedirectToRouteResult SuaSoLuong(int SanPhamID, int soluongmoi)
        {
            // tìm carditem muon sua
            List<Giohang> giohang = Session["giohang"] as List<Giohang>;
            Giohang itemSua = giohang.FirstOrDefault(m => m.SanPhamID == SanPhamID);
            if (itemSua != null)
            {
                itemSua.SoLuong = soluongmoi;
            }
            return RedirectToAction("Index");
        }
        public RedirectToRouteResult XoaKhoiGio(int SanPhamID)
        {
            List<Giohang> giohang = Session["giohang"] as List<Giohang>;
            Giohang itemXoa = giohang.FirstOrDefault(m => m.SanPhamID == SanPhamID);
            if (itemXoa != null)
            {
                giohang.Remove(itemXoa);
            }
            return RedirectToAction("Index");
        }
        
    }
}