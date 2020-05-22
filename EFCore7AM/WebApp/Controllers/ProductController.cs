using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        DataBaseContext db = new DataBaseContext();
        public IActionResult Index()
        {
            List<Product> data = db.Products.ToList();
            return View(data);
        }
        public IActionResult Create()
        {
            ViewBag.CategoryList = db.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product model)
        {
            db.Products.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            ViewBag.CategoryList = db.Categories.ToList();
            Product model = db.Products.Find(id);
            return View("Create", model);
        }
        [HttpPost]
        public IActionResult Edit(Product model)
        {
            db.Products.Update(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Product product = db.Products.Find(id);
            if(product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}