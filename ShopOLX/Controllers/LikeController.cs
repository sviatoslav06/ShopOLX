using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using ShopOLX.Helpers;

namespace ShopOLX.Controllers
{
    public class LikeController : Controller
    {
        private readonly ShopDbContext ctx;

        public LikeController(ShopDbContext ctx)
        {
            this.ctx = ctx;
        }

        public IActionResult Index()
        {
            List<int>? ids = HttpContext.Session.Get<List<int>>("liked_items");

            List<Product> products = new();

            if (ids != null)
                products = ctx.Products.Where(x => ids.Contains(x.Id)).ToList();

            return View(products);
        }

        public IActionResult Like(int id)
        {
            List<int>? ids = HttpContext.Session.Get<List<int>>("liked_items");

            if (ids == null)
                ids = new List<int>();

            ids.Add(id);

            HttpContext.Session.Set("liked_items", ids);

            return RedirectToAction("Index", "Home");
        }
        public IActionResult UnLike(int id)
        {
            List<int>? ids = HttpContext.Session.Get<List<int>>("liked_items");

            for (int i = 0; i < ids.Count; i++)
            {
                if (ids[i] == id)
                {
                    ids.RemoveAt(i);
                }
            }

            //ids.RemoveAt(id);

            HttpContext.Session.Set("liked_items", ids);

            return RedirectToAction("Index", "Like");
        }
    }
}
