using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UncafezinWeb.Data;
using UncafezinWeb.Entities;

namespace UncafezinWeb.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        UncafezinContext context = new UncafezinContext();
        const string PromoCode = "FREE";

        // GET: Checkout/AddressAndPayment
        public ActionResult AddressAndPayment()
        {
            return View();
        }


        // POST: Checkout/AddressAndPayment
        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection collection)
        {
            var order = new Order();
            TryUpdateModel(order);

            try
            {
                if (string.Equals(collection["PromoCode"], PromoCode, StringComparison.OrdinalIgnoreCase) == false)
                {
                    return View(order);
                }
                else
                {
                    order.UserName = User.Identity.Name;
                    order.OrderDate = DateTime.Now;

                    context.Orders.Add(order);
                    context.SaveChanges();

                    var cart = ShoppingCart.GetCart(this.HttpContext);
                    cart.CreateOrder(order);
                    
                    return RedirectToAction("Complete", new { id = order.OrderId });
                }

            }
            catch
            {
                return View(order);
            }
        }


        // GET: Checkout/Delete/5
        public ActionResult Complete(int id)
        {
            bool isValid = context.Orders.Any(o => o.OrderId == id && o.UserName == User.Identity.Name);
            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }

        }
    }
}
