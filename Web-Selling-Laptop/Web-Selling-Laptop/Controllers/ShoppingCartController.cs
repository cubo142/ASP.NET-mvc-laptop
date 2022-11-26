using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Selling_Laptop.Models;

namespace Web_Selling_Laptop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private LaptopDBContext db = new LaptopDBContext();

        // GET: ShoppingCart
        public ActionResult ShowCart()
        {
            if (Session["Cart"] == null)
            {

                return View("ShowCart");
            }
            else
            {
                Cart _cart = Session["Cart"] as Cart;
                return View(_cart);
            }
           
        }
        //Tạo mới giỏ hàng, lấy từ Session
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
        // Thêm sản phẩm vào giỏ hàng
        public ActionResult AddToCart(int id)
        {
            // lấy sản phẩm theo id
            var _lap = db.Laptops.SingleOrDefault(s => s.LaptopId == id);
            if (_lap != null)
            {
                GetCart().Add_Product_Cart(_lap);
            }
            return RedirectToAction("ShowCart", "ShoppingCart");
        }
        // Cập nhật số lượng và tính lại tổng tiền
        public ActionResult Update_Cart_Quantity(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id_lap = int.Parse(Request.Form["idLap"]);
            int _quantity = int.Parse(Request.Form["cartQuantity"]);
            cart.Update_quantity(id_lap, _quantity);

            return RedirectToAction("ShowCart", "ShoppingCart");
        }
        //Xóa dòng sp trong giỏ
        public ActionResult RemoveCart(int id)
        {

            Cart cart = Session["Cart"] as Cart;
            cart.Remove_CartItem(id);
            return RedirectToAction("ShowCart", "ShoppingCart");
            
        }
        // Tính tổng tiền đơn hàng
        public PartialViewResult BagCart()
        {
            decimal total_money_item = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart != null)
                total_money_item = cart.Total_quantity();
            ViewBag.TotalCart = total_money_item;
            return PartialView("BagCart");
        }
        // Các phương thức cho thanh toán
        public ActionResult CheckOut(FormCollection form)
        {
/*            try
            {*/
                Cart cart = Session["Cart"] as Cart;
                OrderPro _order = new OrderPro();

                /*Kiểm tra form idCus có null hay ko*/
                if(form["CodeCustomer"].Equals(""))
                {
                    _order.DateOrder = DateTime.Now;
                    _order.Address = form["AddressDelivery"];
                    _order.UserID = null;
                    _order.CusPro = form["NameCustomer"];
                    _order.SDTPro = form["SDTCustomer"];
                    db.OrderProes.Add(_order);
                    foreach (var item in cart.Items)
                    {
                        // lưu dòng sản phẩm vào chi tiết hóa đơn
                        OrderDetail _order_detail = new OrderDetail();
                        _order_detail.OrderDetailID = _order.OrderID;
                        _order_detail.LaptopId = item._laptop.LaptopId;
                        _order_detail.UnitPrice = (double)item._laptop.Price;
                        _order_detail.Quantity = item._quantity;
                        db.OrderDetails.Add(_order_detail);
                    }
                    db.SaveChanges();
                    cart.ClearCart();
                    return RedirectToAction("Home", "Laptop");
                }
                else {
                _order.DateOrder = DateTime.Now;
                _order.Address = form["AddressDelivery"];
                _order.UserID = int.Parse(form["CodeCustomer"]);
                db.OrderProes.Add(_order);
                foreach (var item in cart.Items)
                {
                    // lưu dòng sản phẩm vào chi tiết hóa đơn
                    OrderDetail _order_detail = new OrderDetail();
                    _order_detail.OrderDetailID = _order.OrderID;
                    _order_detail.LaptopId = item._laptop.LaptopId;
                    _order_detail.UnitPrice = (double)item._laptop.Price;
                    _order_detail.Quantity = item._quantity;
                    db.OrderDetails.Add(_order_detail);
                }
                db.SaveChanges();
                cart.ClearCart();
                return RedirectToAction("Home", "Laptop");
            }
                
/*        }*/
            /*catch
            {
                return Content("Có sai sót! Xin kiểm tra lại thông tin"); ;

            }*/
}
        // Thông báo thanh toán thành công
        public ActionResult CheckOut_Success()
        {
            return View();
        }
    }
}