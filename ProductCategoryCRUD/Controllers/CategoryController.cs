using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductCategoryCRUD.Models;

namespace ProductCategoryCRUD.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        ShopContext shopContext = new ShopContext();
        // GET: Category
        public ActionResult Index()
        {
            IEnumerable<Category> categories = shopContext.Categories;
            ViewBag.Categories = categories;
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Category category)
        {
            shopContext.Categories.Add(category);
            shopContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Category category = shopContext.Categories.Find(id);
            if (category != null)
            {
                return View(category);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            shopContext.Entry(category).State = System.Data.Entity.EntityState.Modified;
            shopContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Category category = shopContext.Categories.Find(id);
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Category category = shopContext.Categories.Find(id);
            shopContext.Categories.Remove(category);
            shopContext.SaveChanges();
            return RedirectToAction("Index");

        }


        protected override void Dispose(bool disposing)
        {
            shopContext.Dispose();
            base.Dispose(disposing);
        }
    }
}