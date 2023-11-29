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
            return View();
        }

         // GET: Store/Browse
        public ActionResult Browse(string category)
        {
            var categories = context.Categories.Include("Products").Single(c => c.Name == category);
            return View(categories);
        }

        // GET: Store/Details/5
        public ActionResult Details(int id)
        {
            var productItem = context.Products.Find(id);
            return View(productItem);
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