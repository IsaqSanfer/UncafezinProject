using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Uncafezin.WebAppUltimate.Data;
using Uncafezin.WebAppUltimate.Entities;

namespace Uncafezin.WebAppUltimate.Controllers
{
    public class FakeProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FakeProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FakeProducts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProductTab.Include(p => p.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FakeProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductTab == null)
            {
                return NotFound();
            }

            var product = await _context.ProductTab
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: FakeProducts/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.CategoryTab, "CategoryId", "CategoryName");
            return View();
        }

        // POST: FakeProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Description,Stock,ImgUrl,CategoryId,CategoryName")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.CategoryTab, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // GET: FakeProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductTab == null)
            {
                return NotFound();
            }

            var product = await _context.ProductTab.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.CategoryTab, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // POST: FakeProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Description,Stock,ImgUrl,CategoryId,CategoryName")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.CategoryTab, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        // GET: FakeProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductTab == null)
            {
                return NotFound();
            }

            var product = await _context.ProductTab
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: FakeProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductTab == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProductTab'  is null.");
            }
            var product = await _context.ProductTab.FindAsync(id);
            if (product != null)
            {
                _context.ProductTab.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return (_context.ProductTab?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
