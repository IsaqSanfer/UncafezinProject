using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Uncafezin.WebAppUltimate.Models;
using Uncafezin.WebAppUltimate.Services;

namespace Uncafezin.WebAppUltimate.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }


        // GET: ProductController
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> Index()
        {
            var items = await _productService.GetAllProducts();
            if(items == null)
            {
                return View("Error");
            }
            return View(items);
        }

        // GET: ProductController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var item = await _productService.GetProductById(id);
            if (item == null)
            {
                return View("Error");
            }

            return View(item);
        }

        // GET: ProductController/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryId = new SelectList(await _categoryService.GetAllCategories(), "CategoryId", "CategoryName");

            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _productService.CreateProduct(productViewModel);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    //return View();
                }
            }
            else
            {
                ViewBag.CategoryId = new SelectList(await _categoryService.GetAllCategories(), "CategoryId", "CategoryName");
            }

            return View(productViewModel);
        }

        // GET: ProductController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.CategoryId = new SelectList(await _categoryService.GetAllCategories(), "CategoryId", "CategoryName");

            var item = await _productService.GetProductById(id);
            if (item == null)
            {
                return View("Error");
            }

            return View(item);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                await _productService.UpdateProduct(productViewModel);
                return RedirectToAction(nameof(Index));
            }
            
            return View(productViewModel);
        }

        // GET: ProductController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _productService.GetProductById(id);

            if (item == null)
            {
                return View("Error");
            }

            return View(item);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var item = 
                await _productService.DeleteProduct(id);

            //if (!item) { return View("Error"); }
            return RedirectToAction(nameof(Index));
        }
    }
}
