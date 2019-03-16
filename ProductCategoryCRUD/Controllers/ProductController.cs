using ProductCategoryCRUD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductCategoryCRUD.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        ShopContext shopContext = new ShopContext();


        public ActionResult Index()
        {
            List<Category> categories = shopContext.Categories.ToList();
            categories.Insert(0, new Category { Name = "All", CategoryId = 0 });
            ViewBag.Categories = categories;

            return View();
        }

        public PartialViewResult GetData(string categoryName, int pageNum = 1)
        {
            int pageSize = 3;
            IEnumerable<Product> products = shopContext.Products.Include(p => p.Category);

            if (categoryName != null && categoryName != "All")
            {
                products = products.Where(p => p.Category.Name == categoryName);
            }

            IEnumerable<Product> productsPerPage = products.Skip((pageNum - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = pageNum, PageSize = pageSize, TotalItems = products.ToList().Count };
            IndexViewModel indexViewModel = new IndexViewModel { PageInfo = pageInfo, Products = productsPerPage };
            
            return PartialView("_PartialViewGetData",indexViewModel);
        }


        [HttpGet]
        [Authorize(Roles ="admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Product product = shopContext.Products.Find(id);
            if (product != null)
            {
                SelectList selectListItems = new SelectList(shopContext.Categories, "CategoryId", "Name");
                ViewBag.categoryItems = selectListItems;

                return PartialView(product);
            }

            return HttpNotFound();
        }

        [HttpPost]
        [Authorize(Roles ="admin")]
        public ActionResult Edit(Product product)
        {
            shopContext.Entry(product).State = EntityState.Modified;
            shopContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles ="admin")]
        public ActionResult Add()
        {
            SelectList selectListItems = new SelectList(shopContext.Categories, "CategoryId", "Name");
            ViewBag.categoryItems = selectListItems;
            return View();
        }
        [HttpPost]
        [Authorize(Roles ="admin")]
        public ActionResult Add(Product product)
        {
            shopContext.Products.Add(product);
            shopContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Authorize(Roles ="admin")]
        public ActionResult Delete(int? id)
        {
            Product product = shopContext.Products.Find(id);
            if (id == null)
            {
                return HttpNotFound();
            }
            return PartialView(product);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            Product product = shopContext.Products.Find(id);
            if (id == null)
            {
                return HttpNotFound();
            }
            shopContext.Products.Remove(product);
            shopContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            //Product product = shopContext.Products.Find(id);
            Product product = shopContext.Products.Include(i => i.Category).FirstOrDefault(x => x.ProductID == id);
            if (product != null)
            {
                return PartialView(product);
            }
            return View("Index");
        }

        protected override void Dispose(bool disposing)
        {
            shopContext.Dispose();
            base.Dispose(disposing);
        }
    }
}