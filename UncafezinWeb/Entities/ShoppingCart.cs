using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UncafezinWeb.Data;

namespace UncafezinWeb.Entities
{
    public partial class ShoppingCart
    {
        UncafezinContext context = new UncafezinContext();
        public string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";

        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }

        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        public void AddToCart(Product product)
        {
            // buscando itens do carrinho
            var cartItem = context.Carts.SingleOrDefault(c => c.CartId == ShoppingCartId && c.ProductId == product.ProductId);

            if (cartItem == null)
            {
                // se não tiver itens, cria novo carrinho
                cartItem = new Cart
                {
                    CartId = ShoppingCartId,
                    ProductId = product.ProductId,
                    Count = 1,
                    DateCreated = DateTime.Now,
                };
                context.Carts.Add(cartItem);
            }
            else
            {
                cartItem.Count++;   // add mais se já existe
            }

            context.SaveChanges();
        }

        public int RemoveFromCart(int id)
        {
            // buscando itens do carrinho
            var cartItem = context.Carts.SingleOrDefault(c => c.CartId == ShoppingCartId && c.RecordId == id);
            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    context.Carts.Remove(cartItem);
                }
                context.SaveChanges();
            }
            return itemCount;
        }

        public void EmptyCart()
        {
            var cartItems = context.Carts.Where(cart => cart.CartId == ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                context.Carts.Remove(cartItem);
            }
            context.SaveChanges();
        }

        public List<Cart> GetCartItems()
        {
            return context.Carts.Where(cart => cart.CartId == ShoppingCartId).ToList();
        }

        public int GetCount()
        {
            int? count = (from cartItems in context.Carts where cartItems.CartId == ShoppingCartId select (int?)cartItems.Count).Sum();

            return count ?? 0;
        }

        public decimal GetTotal()
        {
            decimal? total = (from cartItems in context.Carts where cartItems.CartId == ShoppingCartId select (int?)cartItems.Count * cartItems.Product.Price).Sum();
            return total ?? decimal.Zero;
        }


        public int CreateOrder(Order order)
        {
            decimal orderTotal = 0;
            var cartItems = GetCartItems();

            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    ProductId = item.ProductId,
                    OrderId = order.OrderId,
                    UnitPrice = item.Product.Price,
                    Quantity = item.Count
                };

                orderTotal += (item.Count * item.Product.Price);
                context.OrderDetails.Add(orderDetail);
            }

            order.Total = orderTotal;
            context.SaveChanges();
            EmptyCart();

            return order.OrderId;
        }

        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    Guid tempCartId = Guid.NewGuid();
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }

        public void MigrateCart(string userName)
        {
            var shoppingCart = context.Carts.Where(c => c.CartId == ShoppingCartId);

            foreach (Cart item in shoppingCart)
            {
                item.CartId = userName;
            }
            context.SaveChanges();
        }
    }
}