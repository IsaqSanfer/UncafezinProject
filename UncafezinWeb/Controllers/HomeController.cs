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

         // GET: Store/Browse
        public ActionResult Browse(int id)
        {   //single() pq não terá duas categorias iguais
            var categories = context.Categories.Include("Products").SingleOrDefault(c => c.CategoryId == id); 
            return View(categories);
        }

        // GET: Store/Details/5
        public ActionResult Details(int id)
        {
            var productItem = context.Products.Find(id);
            return View(productItem);
        }

        // GET: /Store/Dept

        [ChildActionOnly]
        public ActionResult DeptMenu()
        {
            var categories = context.Categories.ToList();
            return PartialView(categories);
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