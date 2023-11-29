using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Uncafezin.ProductAPI.Models;

namespace Uncafezin.ProductAPI.Data
{
    public class ProductAPIContext : DbContext
    {
        public ProductAPIContext (DbContextOptions<ProductAPIContext> options) : base(options) { }

        public DbSet<Uncafezin.ProductAPI.Models.Category> Category { get; set; } = default!;
        public DbSet<Uncafezin.ProductAPI.Models.Product>? Product { get; set; } 
    }
}