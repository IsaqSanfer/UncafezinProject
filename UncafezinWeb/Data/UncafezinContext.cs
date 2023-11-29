using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UncafezinWeb.Data
{
    public class UncafezinContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public UncafezinContext() : base("name=UncafezinContext") { }

        public System.Data.Entity.DbSet<UncafezinWeb.Entities.Product> Products { get; set; }
        public System.Data.Entity.DbSet<UncafezinWeb.Entities.Category> Categories { get; set; }
        public System.Data.Entity.DbSet<UncafezinWeb.Entities.Cart> Carts { get; set; }
        public System.Data.Entity.DbSet<UncafezinWeb.Entities.Order> Orders { get; set; }
        public System.Data.Entity.DbSet<UncafezinWeb.Entities.OrderDetail> OrderDetails { get; set; }
    }
}
