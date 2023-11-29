using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Uncafezin.WebApp.Models;

namespace Uncafezin.WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Uncafezin.WebApp.Models.ProductViewModel>? ProductViewModel { get; set; }
    }
}