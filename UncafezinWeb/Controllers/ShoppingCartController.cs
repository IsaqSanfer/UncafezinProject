using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UncafezinWeb.Data;
using UncafezinWeb.Entities;
using UncafezinWeb.Models;

namespace UncafezinWeb.Controllers
{
    public class ShoppingCartController : Controller
    {
        UncafezinContext context = new UncafezinContext();

        // GET: ShoppingCart
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            var items = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal(),
            };
            return View(items);
        }

        // GET: ShoppingCart/AddToCart/5
        public ActionResult AddToCart(int id)
        {
            var addProduct = context.Products.SingleOrDefault(product => product.ProductId == id);
            var cart = ShoppingCart.GetCart(this.HttpContext);

            cart.AddToCart(addProduct);
            
            return RedirectToAction("Index");
        }

        // POST: ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            string productName = context.Carts.SingleOrDefault(item => item.RecordId == id).Product.Name;
            int itemCount = cart.RemoveFromCart(id);

            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(productName) + "foi removido do carrinho.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            
            return Json(results);
        }

        // GET: ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }

        // GET: ShoppingCart
        [ChildActionOnly]
        public ActionResult CartCompact()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            var items = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal(),
            };
            return PartialView(items);
        }

    }
}
