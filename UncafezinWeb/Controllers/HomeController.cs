using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UncafezinWeb.Data;
using UncafezinWeb.Entities;

namespace UncafezinWeb.Controllers
{
    public class HomeController : Controller
    {
        UncafezinContext context = new UncafezinContext();
        public ActionResult Index()
        {
            var categories = context.Categories.ToList();
            return View(categories);
        }

        public ActionResult Browse(int id)
        {   
            //single() pq não terá duas categorias iguais
            var categories = context.Categories.Include("Products").SingleOrDefault(c => c.CategoryId == id);
            return View(categories);
        }

        public ActionResult Details(int id)
        {
            var productItem = context.Products.Find(id);
            return View(productItem);
        }

        [ChildActionOnly]
        public ActionResult DeptMenu()
        {
            var categories = context.Categories.ToList();
            return PartialView(categories);
        }

        [ChildActionOnly]
        public ActionResult DeptProduct()
        {
            var categoriesId = context.Categories.Select(c => c.CategoryId).ToList();
            var twoProducts = new List<Product>();

            foreach (var categoryId in categoriesId)
            {
                // enviando id por id para buscar os produtos...
                var categoryWithProducts = context.Categories
                    .Include("Products")
                    .SingleOrDefault(c => c.CategoryId == categoryId);

                if (categoryWithProducts != null)
                {
                    twoProducts.AddRange(categoryWithProducts.Products.Take(2));
                }
            }

            return PartialView(twoProducts);
        }


        public ActionResult Stores()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}