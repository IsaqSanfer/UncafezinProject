using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Uncafezin.WebAppUltimate.Models;
using Uncafezin.WebAppUltimate.Services;

namespace Uncafezin.WebAppUltimate.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public HomeController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var items = await _productService.GetAllProducts();
            if (items == null)
            {
                return View("Error");
            }
            return View(items);
        }

        public IActionResult Stores()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
