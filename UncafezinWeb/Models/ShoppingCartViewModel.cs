using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UncafezinWeb.Entities;

namespace UncafezinWeb.Models
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems{ get; set; }
        public decimal CartTotal { get; set; }
    }
}