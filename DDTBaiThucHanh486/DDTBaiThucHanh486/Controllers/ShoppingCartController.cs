//using DDTBaiThucHanh486.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace DDTBaiThucHanh486.Controllers
//{
//    public class ShoppingCartController : Controller
//    {
//        // GET: ShoppingCart
//        Model1 db = new Model1();
//        private string strCart = "Cart";
//        // GET: ShoppingCart

//        public ActionResult Index()
//        {
//            return View();
//        }

//        //lấy giỏ hàng
//        public cartHandle GetCart()
//        {
//            cartHandle carthendle = Session["cartHandle"] as cartHandle;
//            if (carthendle == null || Session["cartHandle"] == null)
//            {
//                carthendle = new cartHandle();
//                Session["cartHandle"] = carthendle;
//            }
//            return carthendle;
//        }

//        //Thêm sản phẩm vào giỏ
//        public ActionResult AddtoCart(string id)
//        {
//            var pro = db.Products.SingleOrDefault(s => s.ProductID == id);
//            if (pro != null)
//            {
//                GetCart().Add(pro);
//            }
//            return RedirectToAction("ShowtoCart", "ShoppingCart");
//        }

//        public ActionResult ShowtoCart()
//        {
//            if (Session["cartHandle"] == null)
//            {
//                //return RedirectToAction("ShowtoCart", "ShoppingCart");  
//                return RedirectToAction("Index", "Products");

//            }
//            cartHandle carthendle = Session["cartHandle"] as cartHandle;
//            return View(carthendle);
//        }


//        public ActionResult Update_Quantity_Cart(FormCollection form)
//        {
//            cartHandle carthandle = Session["cartHandle"] as cartHandle;
//            string id = form["ID_Product"];
//            int quantity = int.Parse(form["Quantity"]);
//            carthandle.Update_Quantity(id, quantity);
//            return RedirectToAction("ShowtoCart", "ShoppingCart");
//        }
//        public ActionResult Delete(string id)
//        {
//            cartHandle cart = Session["cartHandle"] as cartHandle;
//            cart.RemoveCart(id);
//            //kiểm tra nếu hết hàng trong cart thì xóa session
//            if (cart.Items.Count() == 0)
//            {
//                Session["cartHandle"] = null;
//                return RedirectToAction("Index", "Products");
//            }
//            return RedirectToAction("ShowtoCart", "ShoppingCart");
//        }
//        public PartialViewResult BagCart()
//        {
//            int Quantity_Item = 0;
//            cartHandle cart = Session["cartHandle"] as cartHandle;
//            if (cart != null)
//            {
//                Quantity_Item = cart.Total_Quantity();
//            }
//            ViewBag.infoCart = Quantity_Item;

//            return PartialView("BagCart");
//        }

//        [Authorize]
//        public ActionResult DatHang()
//        {
//            //lấy ra userName vừa đăng nhập 
//            //var user = System.Web.HttpContext.Current.User.Identity.GetUserName();
//            if (Session["cartHandle"] == null)
//            {
//                RedirectToAction("Index", "Products");
//            }

//            //tạo đối tượng đơn hàng
//            DonHang ddh = new DonHang();
//            //lấy ra giỏ hàng
//            cartHandle gh = GetCart();
//            //gán userName trong đơn hàng bằng UserName vừa đăng nhập
//            ddh.UserName = user;
//            ddh.Ngaydat = DateTime.Today;
//            //string nd = DateTime.Today.AddDays(3).ToString();
//            //ddh.NgayGiao = DateTime.Parse(nd);
//            db.DonHangs.Add(ddh);
//            db.SaveChanges();
//            foreach (var item in gh.Items)
//            {
//                Chitietdonhang ctdh = new Chitietdonhang();
//                ctdh.DonHangID = ddh.DonHangID;
//                ctdh.ProductID = item.Product.ProductID;
//                ctdh.Quantity = item.Quantity;
//                ctdh.ProductPrice = item.Product.ProductPrice;
//                db.Chitietdonhangs.Add(ctdh);
//            }

//            db.SaveChanges();
//            Session["cartHandle"] = null;
//            return RedirectToAction("Index", "Products");
//        }
//    }
//}