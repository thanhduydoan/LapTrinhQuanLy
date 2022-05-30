using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DDTBaiTapLon486.Models
{
    public class CartItem
    {
        public SanPham _shopping_product { get; set; }
        public int _shopping_quantity { get; set; }
    }
    //Gio hang
    public class Cart
    {
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> cartItems
        {
            get { return items; }
        }
        public void Add(SanPham _pro, int _quantity = 1)
        {
            var item = items.FirstOrDefault(s => s._shopping_product.SanPhamID == _pro.SanPhamID);
            if (item == null)
            {
                items.Add(new CartItem
                {
                    _shopping_product = _pro,
                    _shopping_quantity = _quantity
                });
            }
            else
            {
                item._shopping_quantity += _quantity;
            }
        }
        public void Update_Quantity_Shopping(int id, int _quantity)
        {
            var item = items.Find(s => s._shopping_product.SanPhamID == id);
            if (item != null)
            {
                item._shopping_quantity = _quantity;
            }
        }
        public double Total_Money()
        {
            var total = items.Sum(s => s._shopping_product.DonGia * s._shopping_quantity);
            return total;
        }
        public void Remove_CartItem(int id)
        {
            items.RemoveAll(s => s._shopping_product.SanPhamID == id);
        }
    }
}