using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShopOLX.Controllers
{
    public class ProductController : Controller
    {
        private readonly ShopDbContext ctx;
        public ProductController(ShopDbContext ctx)
        {
            this.ctx = ctx;
        }

        private void LoadCategories()
        {
            this.ViewBag.Categories = new SelectList(ctx.Categories.ToList(), "Id", "Name");
        }

        public IActionResult Index()
        {
            var products = ctx.Products.ToList();

            return View(products);
        }

        public IActionResult Delete(int id)
        {
            var item = ctx.Products.Find(id);

            if (item == null) return NotFound();

            ctx.Products.Remove(item);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            LoadCategories();
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product prod)
        {
            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View(prod);
            }

            ctx.Products.Add(prod);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = ctx.Products.Find(id);

            if (item == null) return NotFound();

            LoadCategories();

            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(Product prod)
        {
            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View(prod);
            }

            ctx.Products.Update(prod);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Show(int id)
        {
            var item = ctx.Products.Find(id);

            if (item == null) return NotFound();

            ViewBag.Message = item;
            
            return View("ShowProduct");
        }
    }
}
