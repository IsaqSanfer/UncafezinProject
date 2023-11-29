using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Uncafezin.WebAppUltimate.Entities;

namespace Uncafezin.WebAppUltimate.Data
{
    public class UncafezinContext : DbContext
    {
        public UncafezinContext (DbContextOptions<UncafezinContext> options) : base(options) {}

        public DbSet<Uncafezin.WebAppUltimate.Entities.Category> CategoryTab { get; set; } = default!;
        public DbSet<Uncafezin.WebAppUltimate.Entities.Product> ProductTab { get; set; } = default!;
    }
}
