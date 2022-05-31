using DDTBaiTapLon486.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDTBaiTapLon486.Controllers
{
    [Authorize(Roles = "User")]
    public class GiohangController : Controller
    {
        private BtlDbContext db = new BtlDbContext();
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ActionResult AddToCart(int id)
        {
            var pro = db.SanPhams.SingleOrDefault(s => s.SanPhamID == id);
            if (pro != null)
            {
                GetCart().Add(pro);
            }
            return RedirectToAction("ShowToCart", "Giohang");
        }
        public ActionResult ShowToCart()
        {
            if (Session["Cart"] == null)
                return RedirectToAction("ShowToCart", "Giohang");
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }
        public ActionResult Update_Quantity_Cart(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id_pro = int.Parse(form["ID_Product"]);
            int quantity = int.Parse(form["Quantity"]);
            cart.Update_Quantity_Shopping(id_pro, quantity);
            return RedirectToAction("ShowToCart", "Giohang");
        }
        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_CartItem(id);
            return RedirectToAction("ShowToCart", "Giohang");
        }
        public PartialViewResult BagCart()
        {
            int _t_item = 0;
            Cart cart = Session["Cart"] as Cart;
            if(cart != null)
                _t_item = cart.Total_Quantity();
                ViewBag.QuantityCart = _t_item;
            return PartialView("BagCart");
        }
        public ActionResult PaySuccess()
        {
            return View();
        }
        public ActionResult CheckOut(FormCollection form)
        {
            try
            {
                Cart cart = Session["Cart"] as Cart;
                Order order = new Order();
                order.OrderDate = DateTime.Now;
                order.CodeCustomer = form["Makhachhang"];
                order.Description = form["Diachigiaohang"];
                db.Order.Add(order);
                foreach(var item in cart.cartItems)
                {
                    OrderDetail orderDetail = new OrderDetail();
                    orderDetail.OrderID = order.OrderID;
                    orderDetail.SanPhamID = item._shopping_product.SanPhamID;
                    orderDetail.UnitPriceSale = item._shopping_product.DonGia;
                    orderDetail.QuantitySale = item._shopping_quantity;
                    db.OrderDetail.Add(orderDetail);
                }
                db.SaveChanges();
                cart.ClearCart();
                return RedirectToAction("PaySuccess", "Giohang");
            }
            catch
            {
                return Content("Lỗi thanh toán");
            }
        }
    }
}