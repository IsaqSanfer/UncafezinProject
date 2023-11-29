using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uncafezin.WebAppUltimate.Models;
using Uncafezin.WebAppUltimate.Services;

namespace Uncafezin.WebAppUltimate.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }


        // GET: CategoryController
        public async Task<ActionResult<IEnumerable<CategoryViewModel>>> Index()
        {
            var items = await _service.GetAllCategories();
            if (items == null)
            {
                return View("Error");
            }
            else
            {
                return View(items);
            }            
        }

        // GET: CategoryController/Details/5
        public async Task<IActionResult> _Details(int id)
        {
            var item = await _service.GetCategoryById(id);
            if(item == null)
            {
                return View("Error");
            }
            return View();
        }

        // GET: CategoryController/Create
        public IActionResult _Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.AddCategory(categoryViewModel);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(); 
                    //return View(categoryViewModel);
                }
            }
            return View(categoryViewModel);
        }

        // GET: CategoryController/Edit/5
        public IActionResult _Edit(int id)
        {
            return View();
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public IActionResult _Delete(int id)
        {
            return View();
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
