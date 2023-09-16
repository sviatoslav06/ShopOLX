using Microsoft.AspNetCore.Mvc;
using ShopOLX.Data;

namespace ShopOLX.Controllers
{
    public class ProductController : Controller
    {
        ShopDbContext ctx = new ShopDbContext();

        // Get all products
        public IActionResult Index()
        {
            var products = ctx.Products.ToList();

            return View(products);
        }

        // Delete product by ID
        public IActionResult Delete(int id)
        {
            var item = ctx.Products.Find(id);

            if (item == null) return NotFound();

            ctx.Products.Remove(item);
            ctx.SaveChanges(); // delete from db

            return RedirectToAction("Index");
        }
    }
}
